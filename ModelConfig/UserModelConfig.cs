using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class UserModelConfig: IEntityTypeConfiguration<UserModel>
{

    public static readonly UserModel Honza = new()
    {
        Id = new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
        Email = "honza@gmail.com",
        UserName = "Honza"
    };

    public static readonly UserModel Jan = new()
    {
        Id = new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
        Email = "jan@gmail.com",
        UserName = "Jan"
    };
    
    public static readonly UserModel Pavel = new()
    {
        Id = new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
        Email = "pavel@gmail.com",
        UserName = "Pavel"
    };
    
    public static readonly UserModel Petr = new()
    {
        Id = new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
        Email = "petr@gmail.com",
        UserName = "Petr"
    };
    
    private static readonly List<UserModel> Users = new()
    {
        Honza, Jan, Pavel, Petr
    };
    
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        const string passwd = "Passwd1!";
        var hasher = new PasswordHasher<UserModel>();
        foreach (var u in Users)
        { 
            hasher.HashPassword(u, passwd);
        }
        builder.HasData(Users);
    }
}