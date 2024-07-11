using Microsoft.EntityFrameworkCore;
using MultiTenant.Api.Chapter08.Data;

namespace MultiTenant.Api.Chapter08.Middleware;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
    {
        var tenantId = context.Request.Headers["Tenant-ID"].ToString();

        if (string.IsNullOrEmpty(tenantId))
        {
            context.Response.StatusCode = 400; // Bad Request
            await context.Response.WriteAsync("Tenant-ID header is missing");
            return;
        }

        var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<TenantDbContext>>();
        context.RequestServices = serviceProvider.CreateScope().ServiceProvider;
        var tenantContext = new TenantDbContext(dbContextOptions, tenantId);
        context.RequestServices.GetRequiredService<IServiceScope>().ServiceProvider.GetService<TenantDbContext>();

        await _next(context);
    }
}
