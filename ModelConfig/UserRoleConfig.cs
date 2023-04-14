using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class UserRoleConfig: IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = RoleModelConfig.Admin.Id,
                UserId = UserModelConfig.Pavel.Id
            },
            new IdentityUserRole<Guid>
            {
                RoleId = RoleModelConfig.Lead.Id,
                UserId = UserModelConfig.Pavel.Id
            },
            new IdentityUserRole<Guid>
            {
                RoleId = RoleModelConfig.Employee.Id,
                UserId = UserModelConfig.Pavel.Id
            },
            new IdentityUserRole<Guid>
            {
                RoleId = RoleModelConfig.Lead.Id,
                UserId = UserModelConfig.Jan.Id
            },
            new IdentityUserRole<Guid>
            {
                RoleId = RoleModelConfig.Employee.Id,
                UserId = UserModelConfig.Jan.Id
            },
            new IdentityUserRole<Guid>
            {
                RoleId = RoleModelConfig.Employee.Id,
                UserId = UserModelConfig.Honza.Id
            },
            new IdentityUserRole<Guid>
            {
                RoleId = RoleModelConfig.Customer.Id,
                UserId = UserModelConfig.Petr.Id
            }
        );
    }
}