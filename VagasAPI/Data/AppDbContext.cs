using Microsoft.EntityFrameworkCore;

namespace VagasApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vaga>? Vagas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=Vagas.db;Cache=Shared");
    }
}
