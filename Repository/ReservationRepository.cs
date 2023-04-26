using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Repository;

public class ReservationRepository: RepositoryBase
{

    public ReservationRepository(DbContextFactory factory, IMapper mapper) : base(factory, mapper)
    {
    }
    
    public async Task<ReservationEntityOutput> AddReservation(ReservationEntityInput reservation, PaymentModel payment)
    {   
        var reservationMapped = _mapper.Map<ReservationModel>(reservation);
        await using var context = _dbFactory.CreateDbContext();
        reservationMapped.Payment = payment;
        reservationMapped.Videotape = await context.VideTape.FindAsync(reservationMapped.Videotape.Id);
        reservationMapped.User = await context.Users.FindAsync(reservationMapped.User.Id);
        
        var result = await context.Reservations.AddAsync(reservationMapped);
        
        await context.SaveChangesAsync();
        var reservationEntity = _mapper.Map<ReservationEntityOutput>(result.Entity);
        return reservationEntity;
    }

    public async Task<ReservationEntityOutput> AddReservation(ReservationModel reservation)
    {
        await using var context = _dbFactory.CreateDbContext();
        Unchanged(context, reservation.Videotape, reservation.User);
        reservation.Payment = new PaymentModel
        {
            Timestamp = reservation.Timestamp,
            Price = 100
        };
        var result = await context.Reservations.AddAsync(reservation);
        await context.SaveChangesAsync();
        var reservationEntity = _mapper.Map<ReservationEntityOutput>(result.Entity);
        return reservationEntity;
    }

    public async Task<ReservationEntityOutput> GetReservation(Guid id)
    {
        await using var context = _dbFactory.CreateDbContext();
        var reservation = await context.Reservations.FindAsync(id) ?? throw new Exception("Reservation not found");
        return _mapper.Map<ReservationEntityOutput>(reservation);
    }

    public async Task<IEnumerable<ReservationEntityOutput>> GetAllReservations()
    {
        await using var context = _dbFactory.CreateDbContext();
        var reservations = await context.Reservations
            .Include(u => u.User)
            .Include(u => u.Videotape)
            .Include(u => u.Payment)
            .ToListAsync();
        return  _mapper.Map<IList<ReservationModel>, IList<ReservationEntityOutput>>(reservations);
    }

    public async Task<IEnumerable<ReservationModel>> GetCollisions(ReservationModel reservationModel)
    {
        await using var context = _dbFactory.CreateDbContext();
        // invert following condition
        return await context.Reservations
            .Where(r => r.Videotape.Id == reservationModel.Videotape.Id)
            .Where(r => 
                (reservationModel.DateFrom <= r.DateFrom && r.DateFrom <= reservationModel.DateTo) ||
                (reservationModel.DateFrom <= r.DateTo && r.DateTo <= reservationModel.DateTo) ||
                (r.DateFrom <= reservationModel.DateFrom && reservationModel.DateTo <= r.DateTo))
            .ToListAsync();
        
    }

    public async Task<IEnumerable<ReservationModel>> GetReservationsWithVideoTape(Guid videoTapeId)
    {
        await using var context = _dbFactory.CreateDbContext();
        var reservations = await context.Reservations
            .Where(r => r.Videotape.Id == videoTapeId)
            .ToListAsync();
        return reservations;
    }
}