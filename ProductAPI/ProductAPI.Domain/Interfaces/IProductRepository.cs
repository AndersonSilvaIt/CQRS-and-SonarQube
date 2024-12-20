using ProductAPI.Domain.Entities;

namespace ProductAPI.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductWithStock();
    }
}