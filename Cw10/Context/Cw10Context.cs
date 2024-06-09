using Cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Context;

public class Cw10Context : DbContext
{
    public Cw10Context()
    {
    }

    public Cw10Context(DbContextOptions<Cw10Context> options) :
        base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(new Category
        {
            IdCategory = 1,
            Name = "Test"
        });
        modelBuilder.Entity<Role>().HasData( new Role
            {
                IdRole = 1,
                Name = "User"
            }
        );
        modelBuilder.Entity<Product>().HasData(new Product
        {
            IdProduct = 1,
            Name = "TestPName",
            Depth = 0.1,
            Height = 0.2,
            Weight = 0.3,
            Width = 0.4
        });
        modelBuilder.Entity<Account>().HasData(new Account
        {
            IdAccount = 1,
            IdRole = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
            Email = "j@k.com",
            Phone = null
        });
        modelBuilder.Entity<ProductsCategories>().HasData(new ProductsCategories
        {
            IdProduct = 1,
            IdCategory = 1
        });
        modelBuilder.Entity<ShoppingCart>().HasData(new ShoppingCart
        {
            IdProduct = 1,
            IdAccount = 1,
            Amount = 10
        });
    }
    
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<Product> Products { get; set; } 
    
    public DbSet<Category> Categories { get; set; } 
    public DbSet<ProductsCategories> ProductsCategories { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    
    
}