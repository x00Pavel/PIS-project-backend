namespace video_pujcovna_back.DTO.Input;

public record VideoTapeEntityInput
{
    public string Title { get; init; }
    public string Description { get; init; }
    public string Genre { get; init; }
}