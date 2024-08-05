using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthApi;

public class ContextBase : IdentityDbContext<ApplicationUser>
{
    public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

    public DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(x => x.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(getConnectionString());
            base.OnConfiguring(optionsBuilder);
        }
    }

    public string getConnectionString()
    {
        return "Server=localhost;Port=5432;Database=AuthApi;User Id=postgres;Password=postgres;";
    }
}
