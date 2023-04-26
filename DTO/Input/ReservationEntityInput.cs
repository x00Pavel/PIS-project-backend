namespace video_pujcovna_back.DTO.Input;

public record ReservationEntityInput
{
    public Guid UserId { get; set; }
    public Guid VideotapeId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}