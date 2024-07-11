using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Api.Chapter08.Data;

namespace MultiTenant.Api.Chapter08.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly TenantDbContext _context;

    public CustomersController(TenantDbContext context)
    {
        _context = context;
    }

    // GET: api/customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }
}
