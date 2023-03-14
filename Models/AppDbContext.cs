using Microsoft.EntityFrameworkCore;

namespace video_pujcovna_back.Models
{
	public class AppDbContext: DbContext
	{

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }

        public AppDbContext()
		{
		}

        public AppDbContext(DbContextOptions options) : base(options)
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



