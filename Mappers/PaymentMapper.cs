using AutoMapper;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Mappers;

public class PaymentMapper: Profile
{
   public PaymentMapper()
   {
      CreateMap<PaymentModel, PaymentEntityOutput>();
      CreateMap<PaymentEntityInput, PaymentModel>();
   }
}