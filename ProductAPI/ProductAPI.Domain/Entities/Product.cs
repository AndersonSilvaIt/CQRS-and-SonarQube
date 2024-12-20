using ProductAPI.Domain.Base;
using ProductAPI.Domain.Validators;
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
            Name = name;
            Validate();
        }

        public void SetPrice(Price price)
        {
            if (price == null)
                throw new ArgumentException("The price is required");

            Price = price;
            Validate();
        }

        public void SetStock(int stock)
        {
            Stock = stock;
            Validate();
        }

        public void UpdateProduct(string name, decimal price, int stock)
        {
            SetName(name);
            SetStock(stock);
            UpdateTimestamp();
        }

        private void Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(errors);
            }
        }
    }
}