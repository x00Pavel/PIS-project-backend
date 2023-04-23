namespace video_pujcovna_back.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

public class StockRepository : IRepository
{
    private readonly DbContextFactory _factory;
    private readonly IMapper _mapper;

    public StockRepository(DbContextFactory factory, IMapper mapper)
    {
        _factory = factory;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StockEntityOutput>> GetAllStocks()
    {
        await using var context = _factory.CreateDbContext();
        return _mapper.Map<IEnumerable<StockEntityOutput>>(await context.Stock.ToListAsync());
    }

    public async Task<StockModel> GetStockModelByName(string name)
    {
        await using var context = _factory.CreateDbContext();
        return await context.Stock.FirstAsync(x => x.Name == name);
    }

    public async Task<StockModel> GetStockByName(string name)
    {
        await using var context = _factory.CreateDbContext();
        return await context.Stock.FirstAsync(x => x.Name == name);
    }

    public async Task<StockEntityOutput> AddStock(StockEntityInput stock)
    {
        await using var context = _factory.CreateDbContext();
        var stockModel = _mapper.Map<StockModel>(stock);

        if (await context.Stock.AnyAsync(x => x.Name == stockModel.Name))
        {
            throw new Exception("Stock already exists");
        }

        await context.Stock.AddAsync(stockModel);
        await context.SaveChangesAsync();
        return _mapper.Map<StockEntityOutput>(stockModel);
    }

    public async Task<StockEntityOutput> DeleteStock(Guid id)
    {
        await using var context = _factory.CreateDbContext();
        var stockModel = await context.Stock.FindAsync(id);

        if (stockModel == null)
        {
            throw new Exception("Stock does not exist");
        }

        context.Stock.Remove(stockModel);
        await context.SaveChangesAsync();
        return _mapper.Map<StockEntityOutput>(stockModel);
    }
}