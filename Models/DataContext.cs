using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace video_pujcovna_back.Models
{
	public class DataContext: DbContext
	{

        public DbSet<Actor> Actors { get; set; }

		public DataContext()
		{
		}

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // Used for EF Migrations
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connection_str = conf.GetConnectionString("videopujcovna");
            optionsBuilder.UseMySql(connection_str, ServerVersion.AutoDetect(connection_str));
        }
    }
}



