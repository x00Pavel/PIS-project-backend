using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Facade;

public class ReservationFacade
{
    private readonly DbContextFactory _contextFactory;
    private readonly IMapper _mapper;
    
    public ReservationFacade(DbContextFactory factory, IMapper mapper)
    {
        _contextFactory = factory;    
        _mapper = mapper;
    }
    
    public async Task<ReservationEntityOutput> AddReservation(ReservationEntityInput reservation)
    {   
        var reservationMapped = _mapper.Map<ReservationModel>(reservation);
        await using (var context = _contextFactory.CreateDbContext())
        {
            var result = await context.Reservations.AddAsync(reservationMapped);
            await context.SaveChangesAsync();
            var reservationEntity = _mapper.Map<ReservationEntityOutput>(result.Entity);
            return reservationEntity;
        }
    }

    public async Task<ReservationEntityOutput> GetReservation(Guid id)
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            var reservation = await context.Reservations.FindAsync(id) ?? throw new Exception("Reservation not found");
            return _mapper.Map<ReservationEntityOutput>(reservation);
        }
    }

    public async Task<IEnumerable<ReservationEntityOutput>> GetAllReservations()
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            var reservations = await context.Reservations.ToListAsync();
            return _mapper.Map<IList<ReservationModel>, IList<ReservationEntityOutput>>(reservations);
        }
    }
}