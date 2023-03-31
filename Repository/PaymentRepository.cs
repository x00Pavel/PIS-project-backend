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
            .Include(x => x.Price)
            .Include(x => x.Timestamp)
            .FirstAsync(x => x.Id == id);
        return _mapper.Map<PaymentEntityOutput>(payment);
    }

    /*
     * TODO: How to filter all user payments?
     * First it is needed to know all user reservations and then
     * filter by their ids
    public async Task<ICollection<PaymentEntityOutput>> GetAllUserPayments()
    {
        await using var context = _dbFactory.CreateDbContext();
        var records = await context.Payment
            .Include(x => x.Price)
            .Include(x => x.Timestamp)
            .FirstAsync(x => x.)
    }
    */

}