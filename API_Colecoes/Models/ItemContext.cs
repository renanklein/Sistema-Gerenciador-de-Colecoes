using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_Colecoes.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public ItemContext(DbContextOptions<ItemContext> options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=Colecoes;Username=postgres;Password=root");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().Property(i => i.ItemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Item>().Property(i => i.Tipo).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.Nome).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.Descricao).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.ImgPath).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.Categoria).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.Autor).IsRequired();
        }
    }
}
