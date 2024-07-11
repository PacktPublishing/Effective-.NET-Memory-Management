using Caching.Api.Chapter08.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caching.Api.Chapter08.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductCatalogService _productCatalogService;

    public ProductController(ProductCatalogService productCatalogService)
    {
        _productCatalogService = productCatalogService;
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProduct(string productId)
    {
        var product = await _productCatalogService.GetProductAsync(productId);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}
