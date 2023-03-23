using video_pujcovna_back.DTO.Input;

namespace video_pujcovna_back.DTO.Output;

public record VideoTapeEntityOutput: VideoTapeEntityInput
{
    public Guid Id { get; init; }
}