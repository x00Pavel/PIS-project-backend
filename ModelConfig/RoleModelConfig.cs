using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.ModelConfig;

public class RoleModelConfig: IEntityTypeConfiguration<RoleModel>
{
    private const string adminGuid = "659195a5-3667-4350-b4c4-550fa8f1908e";
    private const string employeeGuid = "c8ef7cfe-631d-4fdf-8705-9514a78d7f4e";
    private const string leadGuid = "5fc03444-56b7-4ca7-a7de-dd4bec93e44e";

    public static readonly RoleModel Customer = new ()
    {
        Id = Guid.Parse("da055781-5fd2-47d7-86a1-84b2c5ddba08"),
        Name = "customer",
        NormalizedName = "CUSTOMER",
        Description = "Regular customer"
    };

    public static readonly RoleModel Admin = new()
    {
        Id = Guid.Parse(adminGuid),
        Name = "admin",
        NormalizedName = "ADMIN",
        Description = "System administrator"
    };
    
    
    public static readonly RoleModel Lead = new()
    {
        Id = Guid.Parse(leadGuid),
        Name = "lead",
        NormalizedName = "LEAD",
        Description = "Branch lead"
    };
    
    public static readonly RoleModel Employee = new()
    {
        Id = Guid.Parse(employeeGuid),
        Name = "employee",
        NormalizedName = "EMPLOYEE",
        Description = "Regular employee"
    };

    public void Configure(EntityTypeBuilder<RoleModel> builder)
    {   
        builder.HasData(Admin, Lead, Employee, Customer);
    }
}