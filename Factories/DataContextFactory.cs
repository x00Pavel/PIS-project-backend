using System;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Factories
{
    public class DataContextFactory : IDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var conn_str = config.GetConnectionString("videopujcovna");

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(conn_str, ServerVersion.AutoDetect(conn_str));

            return new DataContext(optionsBuilder.Options);
        }
    }
}

