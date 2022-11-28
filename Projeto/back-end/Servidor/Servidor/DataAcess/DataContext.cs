using Microsoft.EntityFrameworkCore;
using Servidor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Servidor.DataAcess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Vendas)
            .WithOne(v=> v.Vendedor);

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Questionamento> Questionamentos { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<StatusVenda>StatusVendas { get; set; }
        public DbSet<Venda> Vendas { get; set; }

    }

}