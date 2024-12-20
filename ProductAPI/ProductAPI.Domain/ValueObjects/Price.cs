namespace ProductAPI.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; private set; }
        public string Currency { get; private set; }

        private Price()
        {
            
        }

        public Price(decimal value, string currency)
        {
            if (value <= 0)
                throw new ArgumentException("Price is required");

            Value = value;
            Currency = currency ?? throw new ArgumentException(nameof(currency));
        }
    }
}