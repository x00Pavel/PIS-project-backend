using AutoMapper;
using video_pujcovna_back.Repository;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Facades;

public class ReservationFacade : FacadeBase<ReservationRepository>
{
    public ReservationFacade(ReservationRepository reservationFacade, IMapper mapper) : base(reservationFacade, mapper)
    {
    }

    public async Task<ReservationEntityOutput> AddReservation(ReservationEntityInput reservation)
    {
        
        var reservationModel = Mapper.Map<ReservationModel>(reservation);
        var collisions = await Repository.GetCollisions(reservationModel);
        
        Console.WriteLine(string.Join(", ", collisions.Select(c => c.Id)));
        
        if (collisions.Any())
        {
            throw new Exception("Reservation collision");
        }
        
        return await Repository.AddReservation(reservationModel);
    }
}