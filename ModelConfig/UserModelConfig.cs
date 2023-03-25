using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class UserModelConfig: IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasData(
            new UserModel
            {
                Id = Guid.NewGuid(),
                Username = "honza@gmail.com",
                Password = "1234",
                RoleId = RoleModelConfig.Admin.Id
            },
            new UserModel
            {
                Id = Guid.NewGuid(),
                Username = "jan@gmail.com",
                Password = "1234",
                RoleId = RoleModelConfig.Customer.Id
            }
            );
    }
}