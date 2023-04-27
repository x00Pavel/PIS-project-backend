using video_pujcovna_back.Validators;

namespace video_pujcovna_back.DTO.Input;

public record ActorEntity
{
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string NameAndSurname { get; init; }
}