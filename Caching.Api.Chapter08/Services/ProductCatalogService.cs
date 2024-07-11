using Caching.Api.Chapter08.Repositories;

namespace Caching.Api.Chapter08.Services;

public record Product(string Id, string Name);

public class ProductCatalogService
{
    private readonly CacheService _cacheService;
    private readonly IProductRepository _productRepository;

    public ProductCatalogService(CacheService cacheService, IProductRepository productRepository)
    {
        _cacheService = cacheService;
        _productRepository = productRepository;
    }

    public async Task<Product> GetProductAsync(string productId)
    {
        var cacheKey = $"product:{productId}";
        var cachedProduct = await _cacheService.GetCacheAsync<Product>(cacheKey);

        if (cachedProduct != null)
        {
            return cachedProduct;
        }

        var product = await _productRepository.GetProductAsync(productId);
        await _cacheService.SetCacheAsync(cacheKey, product, TimeSpan.FromMinutes(30));

        return product;
    }
}

