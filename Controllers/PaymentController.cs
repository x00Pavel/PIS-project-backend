using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController: ControllerBase<PaymentRepository>
{
    public PaymentController(PaymentRepository repository) : base(repository)
    {
        
    }

    [HttpGet("{id}")]
    public async Task<PaymentEntityOutput> GetPayment(Guid id)
    {
        return await Repository.GetPayment(id);
    }

    /*
    [HttpGet("all")]
    public async Task<IEnumerable<PaymentEntityOutput>> GetAllPayments()
    {
        return await Repository.GetAllUserPayments();
    }
    */
}