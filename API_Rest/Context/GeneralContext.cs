using API_Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Rest.Context
{
    public class GeneralContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Puzzles> Puzzles { get; set; }
        public DbSet<UserGallery> UsersGallerys { get; set; }
        public DbSet<UserPiece> UserPieces { get; set; }
        public DbSet<UserPuzzle> UserPuzzles {  get; set; }
        public GeneralContext()
        {
            Database.EnsureCreated();
            Users.Load();
            Puzzles.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=;database=puzzle_app",new MySqlServerVersion(new Version(8, 11, 0)));
        }
    }
}
