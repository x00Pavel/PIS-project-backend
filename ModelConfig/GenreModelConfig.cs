using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class GenreModelConfig: IEntityTypeConfiguration<GenreModel>
{   
    public static readonly GenreModel Action = new()
    {
        Name = "action"
    };
    
    public static readonly GenreModel Adventure = new()
    {
            Name = "adventure"
        };

    public static readonly GenreModel Comedy = new()
    {
            Name = "comedy"
        };
    
    public void Configure(EntityTypeBuilder<GenreModel> builder)
    {
        builder.HasData(
            Action,
            Adventure,
            Comedy
        );
    }     
}
