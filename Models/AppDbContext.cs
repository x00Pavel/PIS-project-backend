using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.ModelConfig;

namespace video_pujcovna_back.Models
{
	public class AppDbContext: IdentityDbContext<UserModel, RoleModel, Guid>
	{

        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<VideotapeModel> VideTape { get; set; }
        public DbSet<GenreModel> Genre { get; set; }
        public DbSet<ActorModel> Actors { get; set; }
        public DbSet<PaymentModel> Payment { get; set; }
        public DbSet<StockModel> Stock { get; set; }

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
            optionsBuilder.UseMySql(connection_str, ServerVersion.AutoDetect(connection_str)).EnableDetailedErrors();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleModelConfig());
            modelBuilder.ApplyConfiguration(new UserModelConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new GenreModelConfig());
            modelBuilder.ApplyConfiguration(new ActorModelConfig());
            modelBuilder.ApplyConfiguration(new StockModelConfig());
        }
    }
}



