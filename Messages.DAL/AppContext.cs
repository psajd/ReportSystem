using Messages.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Messages.DAL;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies() // подключение lazy loading
            .UseSqlite("Data Source=helloapp.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Messages)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

            builder
                .HasMany(x => x.Reports)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

            builder
                .HasMany(x => x.Workers)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);
        });

        modelBuilder.Entity<Message>(builder =>
        {
            builder.HasKey(x => x.Id);
        });

        modelBuilder.Entity<Report>(builder =>
        {
            builder.HasKey(x => x.Id);
        });

        modelBuilder.Entity<Employee>(builder =>
        {
            builder.HasKey(x => x.Id);
        });
    }
}