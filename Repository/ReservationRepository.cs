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
        Console.WriteLine(reservationMapped);
        reservationMapped.Payment = payment;
        reservationMapped.Videotape = await context.VideTape.FindAsync(reservationMapped.Videotape.Id);
        reservationMapped.User = await context.Users.FindAsync(reservationMapped.User.Id);
        
        var result = await context.Reservations.AddAsync(reservationMapped);
        
        await context.SaveChangesAsync();
        var reservationEntity = _mapper.Map<ReservationEntityOutput>(result.Entity);
        return reservationEntity;
    }

    public async Task<ReservationEntityOutput> AddReservation(ReservationModel reservation, PaymentModel payment)
    {
        await using var context = _dbFactory.CreateDbContext();
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
        var reservations = await context.Reservations.ToListAsync();
        return _mapper.Map<IList<ReservationModel>, IList<ReservationEntityOutput>>(reservations);
    }
}