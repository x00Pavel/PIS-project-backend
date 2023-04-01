using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace video_pujcovna_back.Models;


[Table("Payment")]
public record PaymentModel : BaseModel
{
   [Required] 
   public float Price { get; set; }
   
   [Required]
   public DateTime Timestamp { get; set; }
   
    [Required]
    public Guid PaymentId { get; set; }
    public PaymentModel Payment { get; set; }
}