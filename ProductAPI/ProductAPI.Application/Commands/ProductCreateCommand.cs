using ProductAPI.Domain.ValueObjects;

namespace ProductAPI.Application.Commands
{
    public class ProductCreateCommand : ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "BRL"; // Padrão Brasil

        public int Stock { get; set; }

        public ProductCreateCommand(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public Price GetPrice()
        {
            return new Price(Price, Currency);
        }
    }
}