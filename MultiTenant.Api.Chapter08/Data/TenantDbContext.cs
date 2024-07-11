using Microsoft.EntityFrameworkCore;

namespace MultiTenant.Api.Chapter08.Data;

public class TenantDbContext : DbContext
{
    public readonly string TenantId;

    public TenantDbContext(DbContextOptions<TenantDbContext> options, string tenantId)
        : base(options)
    {
        TenantId = tenantId;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var tenantSchema = $"tenant_{TenantId}";
        optionsBuilder.UseSqlServer($"Server=CrmServerAddress;Database=CrmDataBase;User Id=DbUsername;Password=DbPassword;SearchPath={tenantSchema}");
    }

    public DbSet<Customer> Customers { get; set; }
}
