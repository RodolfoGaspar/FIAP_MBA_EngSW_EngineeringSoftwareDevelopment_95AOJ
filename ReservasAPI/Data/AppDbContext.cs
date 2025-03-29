using Microsoft.EntityFrameworkCore;

namespace ReservasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Reservas>? Reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=Reservas.db;Cache=Shared");
    }
}
