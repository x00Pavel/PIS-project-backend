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

   public bool Paid { get; set; } = false;
}