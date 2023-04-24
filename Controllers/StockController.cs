using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;
namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin")]

public class StockController : ControllerBase<StockRepository>
{
    public StockController(StockRepository repository) : base(repository)
    {
    }

    [HttpGet("all")]
    public async Task<IEnumerable<StockEntityOutput>> GetAllStocks()
    {
        return await Repository.GetAllStocks();
    }

    [HttpPost]
    public async Task<StockEntityOutput> AddStock(StockEntityInput stock)
    {
        return await Repository.AddStock(stock);
    }

    [HttpDelete]
    public async Task<StockEntityOutput> DeleteStock([FromBody] Guid id)
    {
        return await Repository.DeleteStock(id);
    }
}