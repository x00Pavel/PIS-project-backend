using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Repository;

public class PaymentRepository: RepositoryBase
{
    public PaymentRepository(DbContextFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
    {
        
    }

    public async Task<PaymentEntityOutput> GetPayment(Guid id)
    {
        await using var context = _dbFactory.CreateDbContext();
        var payment = await context.Payment
            .FirstAsync(x => x.Id == id);
        return _mapper.Map<PaymentEntityOutput>(payment);
    }

    public async Task<PaymentModel> NewPayment(float price)
    {
        return new PaymentModel()
        {
            Price = price,
            Timestamp = DateTime.Now
        };
    }
}