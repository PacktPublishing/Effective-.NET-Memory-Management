using Caching.Api.Chapter08.Services;

namespace Caching.Api.Chapter08.Repositories;

public interface IProductRepository
{
    public Task<Product> GetProductAsync(string Id);
}
