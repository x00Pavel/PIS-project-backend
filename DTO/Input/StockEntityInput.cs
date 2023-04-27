using video_pujcovna_back.Validators;

public class StockEntityInput
{
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Name { get; set; }
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Description { get; set; }
}