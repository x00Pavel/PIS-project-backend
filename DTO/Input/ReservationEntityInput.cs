namespace video_pujcovna_back.DTO.Input;

public record ReservationEntityInput
{
    public Guid UserId { get; set; }
    public Guid VideotapeId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ReturnDate { get; set; } // TODO: Do we always know this value?
}