using BullMarket.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BullMarket.Web.Repository
{
    public class BullMarketContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Corretagem> Corretagens { get; set; }

        public BullMarketContext(DbContextOptions<BullMarketContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Corretagem>()
                 .Property(e => e.Corretora)
                 .HasConversion(
                     v => v.ToString(),
                     v => (CorretoraEnum)Enum.Parse(typeof(CorretoraEnum), v));

            modelBuilder
                 .Entity<Corretagem>()
                 .Property(e => e.Status)
                 .HasConversion(
                     v => v.ToString(),
                     v => (StatusEnum)Enum.Parse(typeof(StatusEnum), v));

            modelBuilder.Entity<Corretagem>().Property(e => e.ValorCompra).HasColumnType("decimal(18,8)");
            modelBuilder.Entity<Corretagem>().Property(e => e.ValorAgora).HasColumnType("decimal(18,8)");
            modelBuilder.Entity<Corretagem>().Property(e => e.Custos).HasColumnType("decimal(18,8)");
        }
    }
}
