using ProductAPI.Domain.Base;
using ProductAPI.Domain.ValueObjects;

namespace ProductAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public Price Price { get; private set; }
        public int Stock { get; private set; }
        public Product(string name, Price price, int stock)
        {
            SetName(name);
            //SetPrice(price);
            SetStock(stock);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name is required");

            Name = name;
        }

        public void UpdatePrice(Price price)
        {
            if (price == null)
                throw new ArgumentException("The price is required");

            Price = price;
        }

        public void SetStock(int stock)
        {
            if (stock <= 0)
                throw new ArgumentException("The stock is required");

            Stock = stock;
        }

        public void UpdateProduct(string name, decimal price, int stock)
        {
            SetName(name);
            SetStock(stock);
            UpdateTimestamp();
        }
    }
}