using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBancoDigital.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContaDigital> ContasDigitais { get; set; }
        public DbSet<Erros> Erros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaDigital>()
                .HasData(
                    new ContaDigital { Id = 1, Conta = 0001, Saldo = 999.0 },
                    new ContaDigital { Id = 2, Conta = 0002, Saldo = 999.0 },
                    new ContaDigital { Id = 3, Conta = 0003, Saldo = 999.0 }
                );
            modelBuilder.Entity<Erros>()
                .HasData(
                    new Erros { Id = 1, Mensagem = "Saldo insuficiente." }
                );

        }
    }
}
