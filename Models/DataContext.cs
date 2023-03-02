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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection_str = "server=127.0.0.1;user=root;password=root;database=videopujcovna";
            optionsBuilder.UseMySql(connection_str, ServerVersion.AutoDetect(connection_str));
        }
    }
}



