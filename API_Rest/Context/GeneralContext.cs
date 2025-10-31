using API_Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Rest.Context
{
    public class GeneralContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public GeneralContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=;database=puzzle_app",new MySqlServerVersion(new Version(8, 11, 0)));
        }
    }
}
