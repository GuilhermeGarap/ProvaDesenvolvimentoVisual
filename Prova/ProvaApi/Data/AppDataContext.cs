using Microsoft.EntityFrameworkCore;
using ProvaApi.Models;

namespace ApiTeste.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarioss { get; set; } = null!;
        public DbSet<Folha> Folhass { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(u => u.FuncionarioId);
                entity.Property(u => u.Nome).IsRequired();
                entity.Property(u => u.Cpf).IsRequired();
                
            });

            modelBuilder.Entity<Folha>(entity =>
            {
                entity.HasKey(f => f.FolhaId);
                entity.Property(f => f.Valor).IsRequired();
                entity.Property(f => f.QuantHoras).IsRequired();
                entity.Property(f => f.Mes).IsRequired();
                entity.Property(f => f.Ano).IsRequired();
                //f.FuncionarioId
            });

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
