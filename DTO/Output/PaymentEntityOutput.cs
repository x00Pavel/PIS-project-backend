namespace video_pujcovna_back.DTO.Output;

public record PaymentEntityOutput
{
   public float Price { get; set; }
   public DateTime Timestamp {get; set; }
   public Guid Id { get; init; }
}