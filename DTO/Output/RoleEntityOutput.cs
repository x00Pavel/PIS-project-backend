using video_pujcovna_back.Models;

namespace video_pujcovna_back.DTO.Output;

public class RoleEntityOutput
{
    public int Priority { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"{nameof(Priority)}: {Priority}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}";
    }
}