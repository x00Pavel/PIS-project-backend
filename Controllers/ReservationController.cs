using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Facade;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController
{
    private readonly ReservationFacade _reservationFacade;

    public ReservationController(ReservationFacade reservationFacade)
    {
        _reservationFacade = reservationFacade;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ReservationEntityOutput>> GetAllReservations()
    {
        return await _reservationFacade.GetAllReservations();
    }
    
    [HttpGet("{id}")]
    public async Task<ReservationEntityOutput> GetReservation(Guid id)
    {
        return await _reservationFacade.GetReservation(id);
    }
    
    [HttpPost]
    public async Task<ReservationEntityOutput> AddReservation(ReservationEntityInput reservation)
    {
        return await _reservationFacade.AddReservation(reservation);
    }
}