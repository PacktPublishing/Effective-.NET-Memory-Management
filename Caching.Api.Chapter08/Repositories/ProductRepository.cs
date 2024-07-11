using Caching.Api.Chapter08.Services;

namespace Caching.Api.Chapter08.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<Product> GetProductAsync(string Id)
    {
        throw new NotImplementedException();
    }
}