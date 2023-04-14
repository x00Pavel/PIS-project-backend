using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin,lead,employee")]
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

}