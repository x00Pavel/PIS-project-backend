using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class ActorModelConfig: IEntityTypeConfiguration<ActorModel>
{

    private readonly List<ActorModel> _list = new()
    {
        new ActorModel
        {
            Id = new Guid("30b4eff8-93e7-44aa-8eb6-f4ad3e7a414b"),
            NameAndSurname = "Tom Hanks"
        },
        new ActorModel
        {
            Id = new Guid("a6307255-4b26-4759-b2c5-b2c467a7e8e4"),
            NameAndSurname = "Tom Cruise"
        },
        new ActorModel
        {
            Id = new Guid("d12c9848-5bb3-41e0-a84c-96a966750129"),
            NameAndSurname = "Ivan"
        },
        new ActorModel
        {
            Id =  new Guid("e94669cc-2089-494b-a260-615ab41685e0"),
            NameAndSurname = "Honza"
        }
    };


    public void Configure(EntityTypeBuilder<ActorModel> builder)
    {
        builder.HasData(_list);
    }
}