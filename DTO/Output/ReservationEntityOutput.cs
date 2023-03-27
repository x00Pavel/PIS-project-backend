namespace video_pujcovna_back.DTO.Output;

public class ReservationEntityOutput
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid VideotapeId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime Timestamp { get; set; }
}