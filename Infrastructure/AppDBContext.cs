using Domain;
using Infrastructure.Commons;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess;

public class AppDBContext : DbContext
{
    private readonly AppConfiguration _config;
    public AppDBContext(AppConfiguration configuration)
    {
        _config = configuration;
    }
    public AppDBContext(DbContextOptions options, AppConfiguration configuration) : base(options)
    {
        _config = configuration;
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Use default local sqlserver
            optionsBuilder.UseSqlServer(_config.ConnectionStrings.DefaultDB);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());        
    }
}
