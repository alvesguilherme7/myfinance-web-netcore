using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Controllers
{
    public class MyFinanceDbContext : DbContext
    {

        public DbSet<PlanoConta> PlanoConta { get; set; }

        public DbSet<Transacao> Transacao { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            var connectionString = @"Server=localhost;user=SA;password=teste@12345678;database=myfinance;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Transacao>().ToTable("transacao").Property(t => t.PlanoContaId).HasColumnName("planoconta_id");
        }
            
        
    }
}