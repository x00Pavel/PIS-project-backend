using System.Net;
using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;
using video_pujcovna_back.Facades;

namespace video_pujcovna_back.Controllers;

public class ReservationResponse
{
    public ReservationEntityOutput Reservation { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public ICollection<string> Errors { get; set; }
}

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
    public async Task<ReservationResponse> AddReservation(ReservationEntityInput reservation)
    {
        try
        {
            return new ReservationResponse()
            {
                Reservation = await Facade.AddReservation(reservation),
                StatusCode = HttpStatusCode.Created
            };
        }
        catch (Exception e)
        {
            return new ReservationResponse()
            {
                StatusCode = HttpStatusCode.ExpectationFailed,
                Errors = new List<string>()
                {
                    e.Message
                }
            };
        }
    }
}