namespace video_pujcovna_back.DTO.Input;

public record PaymentEntityInput
{
   public float Price { get; set; }
   public DateTime Timestamp {get; set; }
}