using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.Factories;

namespace video_pujcovna_back.Repository;

public class RoleRepository: RepositoryBase
{
    public RoleRepository(DbContextFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
    {
    }

    public async Task<List<string?>> GetAllRoles()
    {
        await using var context = _dbFactory.CreateDbContext();
        return await context.Roles.Select(r => r.Name).ToListAsync();
    }
}