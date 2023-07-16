using Microsoft.EntityFrameworkCore;
using Test_task.Data.Entities;

namespace Test_task.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Еда"
                },
                new Category
                {
                    Id = 2,
                    Name = "Напитки"
                },
                new Category
                {
                    Id = 3,
                    Name = "Автомасла"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Хлеб",
                    CategoryId = 1,
                    Description = "Хлеб белый",
                    Price = 200
                },
                new Product
                {
                    Id = 2,
                    Name = "Вода",
                    CategoryId = 2,
                    Description = "Вода 0.5л",
                    Price = 50
                },
                new Product
                {
                    Id = 3,
                    Name = "ZIC автомасло",
                    CategoryId = 3,
                    Description = "5w-30 4л",
                    Price = 4000
                },
                new Product
                {
                    Id=4,
                    Name = "Sprite",
                    CategoryId = 2,
                    Description = "Безалкогольный напиток 0.5л",
                    Price = 90
                },
                new Product
                {
                    Id= 5,
                    Name = "Масло сливочное",
                    CategoryId = 1,
                    Description = "300г",
                    Price = 199
                },
                new Product
                {
                    Id= 6,
                    Name = "SHELL Helix Ultra",
                    CategoryId = 3,
                    Description = "0w-20 4л",
                    Price = 5000
                }
                );
        }
    }
}
