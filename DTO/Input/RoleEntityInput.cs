using video_pujcovna_back.Validators;

namespace video_pujcovna_back.DTO.Input;

public class RoleEntityInput
{
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Name { get; init; }
}