using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class ActorModelConfig: IEntityTypeConfiguration<ActorModel>
{
    public void Configure(EntityTypeBuilder<ActorModel> builder)
    {
        builder.HasData(
            new ActorModel
            {
                Id = Guid.NewGuid(),
                NameAndSurname = "Tom Hanks"
            },new ActorModel
            {
                Id = Guid.NewGuid(),
                NameAndSurname = "Tom Cruise"
            },new ActorModel
            {
                Id = Guid.NewGuid(),
                NameAndSurname = "Ivan"
            },new ActorModel
            {
                Id = Guid.NewGuid(),
                NameAndSurname = "Honza"
            }
            );
    }
}