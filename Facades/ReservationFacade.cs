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
        var videotapeReservations = await Repository.GetReservationsWithVideoTape(reservationModel.Videotape.Id);
        // Checkin if videotape is already reserved in this time
        // TODO: now only checking for one available videotape in store -> need to check for all videotapes in store based on 
        foreach (var videotapeReservation in videotapeReservations)
        {
            // Searching for collision via start date
            if (reservationModel.ReservationDate >= videotapeReservation.ReservationDate && reservationModel.ReservationDate <= videotapeReservation.ReturnDate)
            {
                throw new Exception("Videotape is already reserved in this time");
            }
            // Searching for collision via end date
            if (reservationModel.ReturnDate >= videotapeReservation.ReservationDate && reservationModel.ReturnDate <= videotapeReservation.ReturnDate)
            {
                throw new Exception("Videotape is already reserved in this time");
            }
        }
        
        return await Repository.AddReservation(reservation);
    }
}