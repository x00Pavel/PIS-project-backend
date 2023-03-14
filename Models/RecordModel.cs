namespace video_pujcovna_back.Models;

public record RecordModel() : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
}