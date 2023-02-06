﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Infra.Data.Produto;
using SistemaCompra.Infra.Data.SolicitacaoCompra;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoAgg.Produto>()
                //.OwnsOne(e => e.Preco)
                .HasData(
                    new ProdutoAgg.Produto("Produto01", "Descricao01", "Madeira", 100)
                );

            modelBuilder.Entity<SolicitacaoAgg.NomeFornecedor>()
            .HasKey(o => o.Id);

            modelBuilder.Entity<SolicitacaoAgg.UsuarioSolicitante>()
               .HasKey(o => o.Id);

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitacaoCompraConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=DESKTOP-G4L0D5R;Database=SistemaCompraDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}