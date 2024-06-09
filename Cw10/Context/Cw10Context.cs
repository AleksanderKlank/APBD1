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
    
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<Product> Products { get; set; } 
    
    public DbSet<Category> Categories { get; set; } 
    
}