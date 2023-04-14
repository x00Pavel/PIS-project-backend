using AutoMapper;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Facades;

public class ReservationFacade
{
    private readonly ReservationRepository _reservationRepository;
    private readonly PaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public ReservationFacade(ReservationRepository reservationRepository, PaymentRepository paymentRepository, IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }
    
    public async Task<ReservationEntityOutput> AddReservation(ReservationEntityInput reservation)
    {
        var payment = await _paymentRepository.NewPayment(12);
        var newReservation = await _reservationRepository.AddReservation(reservation, payment);
        return _mapper.Map<ReservationEntityOutput>(newReservation);
    }
}