using System;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.Models;
namespace video_pujcovna_back.Factories
{
    public class UserContextFactory : IDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var conn_str = config.GetConnectionString("users");

            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            optionsBuilder.UseMySql(conn_str, ServerVersion.AutoDetect(conn_str));

            return new UserContext(optionsBuilder.Options);
        }
    }
}

