using Microsoft.EntityFrameworkCore;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Infrastructure.Context;

namespace ProductAPI.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Name.Equals(name));
        }

        public async Task<IEnumerable<Product>> GetProductWithStock()
        {
            return await _dbSet.Where(p => p.Stock > 0).ToListAsync();
        }
    }
}
