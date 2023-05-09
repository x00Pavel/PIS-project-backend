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
        var reservation = await context.Reservations
            .Include(x => x.Videotape)
            .Include(x => x.Payment)
            .FirstAsync(x => x.Id == id) ?? throw new Exception("Reservation not found");
        return _mapper.Map<ReservationEntityOutput>(reservation);
    }

    public async Task<IEnumerable<ReservationEntityOutput>> GetAllReservations()
    {
        await using var context = _dbFactory.CreateDbContext();
        var reservations = await context.Reservations
            .Include(x => x.Videotape)
            .Include(x => x.Payment)
            .Include(x => x.User)
            .ToListAsync();
        return _mapper.Map<IList<ReservationModel>, IList<ReservationEntityOutput>>(reservations);
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
    
    public async Task<IEnumerable<ReservationModel>> GetCollisions(ReservationEntityOutput reservationEntity)
    {
        await using var context = _dbFactory.CreateDbContext();
        // invert following condition
        return await context.Reservations
            .Where(r => r.Videotape.Title == reservationEntity.VideotapeName && r.Id != reservationEntity.Id)
            .Where(r =>
                (reservationEntity.DateFrom <= r.DateFrom && r.DateFrom <= reservationEntity.DateTo) ||
                (reservationEntity.DateFrom <= r.DateTo && r.DateTo <= reservationEntity.DateTo) ||
                (r.DateFrom <= reservationEntity.DateFrom && reservationEntity.DateTo <= r.DateTo))
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

    public async Task<ReservationEntityOutput> UpdateReservation(ReservationEntityOutput reservationUpdate)
    {
        await using var ctx = _dbFactory.CreateDbContext();
        var reservation = await ctx.Reservations
            .Where(r => r.Id == reservationUpdate.Id)
            .Include(r => r.Payment)
            .FirstOrDefaultAsync() ?? null;
        if (reservation == null)
        {
            throw new Exception("Reservation doesn't exist");
        }

        if (reservation.State != reservationUpdate.State)
        {
            reservation.State = reservationUpdate.State;    
        }

        if (reservationUpdate.Payed != reservation.Payment.Paid)
        {
            reservation.Payment.Paid = reservationUpdate.Payed;
        }
        
        
        if (reservationUpdate.DateFrom != reservation.DateFrom || reservationUpdate.DateTo != reservation.DateTo)
        {
            reservation.DateFrom = reservationUpdate.DateFrom;
        }

        if (reservationUpdate.DateTo != reservation.DateTo)
        {
            reservation.DateTo = reservationUpdate.DateTo;
        }
        
        
        ctx.Reservations.Update(reservation);
        await ctx.SaveChangesAsync();
        return reservationUpdate;
    }
}