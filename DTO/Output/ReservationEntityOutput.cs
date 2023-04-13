namespace video_pujcovna_back.DTO.Output;

public class ReservationEntityOutput
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string VideotapeName { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public DateTime Timestamp { get; set; }
    public string State { get; set; }
}