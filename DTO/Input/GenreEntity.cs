using video_pujcovna_back.Validators;

namespace video_pujcovna_back.DTO.Input;

public record GenreEntity
{
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Name { get; set; }
}
