using Microsoft.EntityFrameworkCore;
using ProvaApi.Models;

namespace ProvaApi.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public DbSet<Folha> Folhas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(f => f.FuncionarioId);
                entity.Property(f => f.Nome).IsRequired();
                entity.Property(f => f.Cpf).IsRequired();
                
            });

            modelBuilder.Entity<Folha>(entity =>
            {
                entity.HasKey(f => f.FolhaId);
                entity.Property(f => f.Valor).IsRequired();
                entity.Property(f => f.Quantidade).IsRequired();
                entity.Property(f => f.Mes).IsRequired();
                entity.Property(f => f.Ano).IsRequired();
                entity.Property(f => f.Salario_Bruto);
                entity.Property(f => f.Imposto_Renda);
                entity.Property(f => f.Inss);
                entity.Property(f => f.Fgts);
                entity.Property(f => f.Salario_Liquido);
            

                entity.HasOne(f => f.Funcionario)            
                    .WithMany(f => f.Folhas)        
                    .HasForeignKey(f => f.FuncionarioId);  
            });


            
            base.OnModelCreating(modelBuilder);
        }
    }
}
