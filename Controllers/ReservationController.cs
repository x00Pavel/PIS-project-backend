using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;
using video_pujcovna_back.Facades;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController: ControllerBase<ReservationRepository, ReservationFacade>
{

    public ReservationController(ReservationRepository reservationRepository, ReservationFacade reservationFacade) : base(reservationRepository ,reservationFacade)
    {
    }
    
    [HttpGet("all")]
    public async Task<IEnumerable<ReservationEntityOutput>> GetAllReservations()
    {
        return await Repository.GetAllReservations();
    }
    
    [HttpGet("{id}")]
    public async Task<ReservationEntityOutput> GetReservation(Guid id)
    {
        return await Repository.GetReservation(id);
    }
    
    [HttpPost]
    public async Task<ReservationEntityOutput> AddReservation(ReservationEntityInput reservation)
    {
        return await _facade.AddReservation(reservation);
        return await Facade.AddReservation(reservation);
    }
}