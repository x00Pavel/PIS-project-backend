using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class VideotapeConfig: IEntityTypeConfiguration<VideotapeModel>
{
    public void Configure(EntityTypeBuilder<VideotapeModel> builder)
    {
        builder.HasData(
            new VideotapeModel
            {
                Id = new Guid(),
                Title = "Tom Hanks",
                Description = "Tom Hanks",
                Genre = new List<GenreModel>
                {
                    GenreModelConfig.Action,
                    GenreModelConfig.Adventure
                },
                Actors = new List<ActorModel>
                {
                    new()
                    {
                        NameAndSurname = "Tom Hanks"
                    },
                    new()
                    {
                        NameAndSurname = "Tom Cruise"
                    }
                }
            },
            new VideotapeModel
            {
                Id = new Guid(),
                Title = "Tom Cruise",
                Description = "Tom Cruise",
                Genre = new List<GenreModel>
                {
                    GenreModelConfig.Action,
                },
                Actors = new List<ActorModel>
                {
                    new()
                    {
                        NameAndSurname = "Honza"
                    },
                    new()
                    {
                        NameAndSurname = "Vojta"
                    }
                }
            },
            new VideotapeModel
            {
                Id = new Guid(),
                Title = "Ivan",
                Description = "Ivan",
                Genre = new List<GenreModel>
                {
                    GenreModelConfig.Comedy
                },
                Actors = new List<ActorModel>
                {
                    new()
                    {
                        NameAndSurname = "Robert Downey Jr."
                    }
                }
            }
        );
    }
}