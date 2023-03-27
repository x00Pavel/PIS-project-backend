using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class VideotapeConfig: IEntityTypeConfiguration<VideotapeModel>
{
    public void Configure(EntityTypeBuilder<VideotapeModel> builder)
    {
        // TODO: Add seed data if needed
    }
}