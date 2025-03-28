using Microsoft.EntityFrameworkCore;

namespace PagamentosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pagamentos>? Pagamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=Pagamentos.db;Cache=Shared");
    }
}
