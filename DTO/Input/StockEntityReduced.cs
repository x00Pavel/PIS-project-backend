using video_pujcovna_back.Validators;

public class StockEntityReduced
{
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Name { get; set; }
}