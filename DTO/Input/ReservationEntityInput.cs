using video_pujcovna_back.Validators;

namespace video_pujcovna_back.DTO.Input;

public record ReservationEntityInput
{
    public Guid UserId { get; set; }
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string VideotapeName { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}