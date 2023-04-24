using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class StockModelConfig: IEntityTypeConfiguration<StockModel>
{
    private readonly List<StockModel> _list = new()
    {
        new StockModel
        {
            Id = new Guid("30b4eff8-93e7-44aa-8eb6-f4ad3e7a414a"),
            Name = "Main stock",
            Description = "Main stock description"
        },

    };

    public void Configure(EntityTypeBuilder<StockModel> builder)
    {
        builder.HasData(_list);
    }
}