using System.Net;
using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;
using video_pujcovna_back.Facades;
using JsonResult = video_pujcovna_back.Repository.JsonResult;

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
    public async Task<JsonResult> GetAllReservations()
    {
        try
        {
            return new JsonResult()
            {
                Status = HttpStatusCode.OK,
                Data = await Repository.GetAllReservations()
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult()
            {   
                
                Errors = new[] { "Error while getting all reservations" },
                Status = HttpStatusCode.ExpectationFailed
            };
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ReservationEntityOutput> GetReservation(Guid id)
    {
        return await Repository.GetReservation(id);
    }
    
    [HttpPost]
    public async Task<JsonResult> AddReservation(ReservationEntityInput reservation)
    {
        try
        {
            return new JsonResult()
            {
                Data = await Facade.AddReservation(reservation),
                Status = HttpStatusCode.Created
            };
        }
        catch (Exception e)
        {   
            Console.Error.WriteLine(e);
            return new JsonResult()
            {
                Status = HttpStatusCode.ExpectationFailed,
                Errors = new List<string>()
                {
                    e.Message
                }
            };
        }
    }

    [HttpPut]
    public async Task<JsonResult> UpdateReservation(ReservationEntityOutput reservation)
    {
        try
        {
            return new JsonResult
            {
                Data = await Facade.UpdateReservation(reservation),
                Status = HttpStatusCode.OK
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult
            {
                Errors = new[] { "Error while updating reservations", e.Message },
                Status = HttpStatusCode.ExpectationFailed
            };
        }
    }
}