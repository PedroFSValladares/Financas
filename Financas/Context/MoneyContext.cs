using Financas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Financas.Context {
    public class MoneyContext : DbContext{
        public MoneyContext(DbContextOptions<MoneyContext> options) : base(options) { }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Transação> Transacoes { get; set; }
        public DbSet<Meta> Metas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Conta>().Property(x => x.Saldo)
                .HasDefaultValue(0);
            modelBuilder.Entity<Conta>().HasIndex(x => x.Login).IsUnique();
            modelBuilder.Entity<Transação>().Property(x => x.Data)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
