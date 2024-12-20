using ProductAPI.Domain.Entities;

namespace ProductAPI.Application.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public static ProductDTO FromProduct(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Price = product.Price.Value,
                Stock = product.Stock,
                Name = product.Name
            };
        }
    }
}