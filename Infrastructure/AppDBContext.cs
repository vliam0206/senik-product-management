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
        // Use local sqlserver
        //optionsBuilder.UseSqlServer(_config.ConnectionStrings.DefaultDB);

        // Use local postgresql
        //optionsBuilder.UseNpgsql(_config.ConnectionStrings.LocalPostgresDB);

        // Use heroku postgressql    
        optionsBuilder.UseNpgsql(_config.ConnectionStrings.HerokuPostgres);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());        
    }
}
