using AutoMapper;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Mappers;

public class StockMapper: Profile
{
    public StockMapper()
    {
        CreateMap<StockModel, StockEntityOutput>();
        CreateMap<StockEntityInput, StockModel>();
    }
}