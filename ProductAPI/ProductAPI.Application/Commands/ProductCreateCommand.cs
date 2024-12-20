namespace ProductAPI.Application.Commands
{
    public class ProductCreateCommand : ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public ProductCreateCommand(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}