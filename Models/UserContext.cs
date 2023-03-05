using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace video_pujcovna_back.Models
{
	public class UserContext: DbContext
	{

		public DbSet<User> Users { get; set; }

		public UserContext()
		{
		}

		public UserContext(DbContextOptions options) : base(options)
		{
		}

		// Used for EF Migrations
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

			var conf = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var connection_str = conf.GetConnectionString("users");
            optionsBuilder.UseMySql(connection_str, ServerVersion.AutoDetect(connection_str));
        }
    }
}

