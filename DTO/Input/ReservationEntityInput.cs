namespace video_pujcovna_back.DTO.Input;

public record ReservationEntityInput
{
    public DateTime ReservationDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Guid UserId { get; set; }
    public Guid RecordId { get; set; }
    
}