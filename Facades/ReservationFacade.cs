using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
        
        if (collisions.Any())
        {
            throw new Exception("Reservation collision");
        }
        
        return await Repository.AddReservation(reservationModel);
    }

    public async Task<ReservationEntityOutput> UpdateReservation(ReservationEntityOutput reservationUpdate)
    {
        var collisions = await Repository.GetCollisions(reservationUpdate);
        if (collisions.Any())
        {
            throw new Exception("Collision with other reservations");
        }
        return await Repository.UpdateReservation(reservationUpdate);
    }
}