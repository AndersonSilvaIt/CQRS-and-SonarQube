﻿namespace ProductAPI.Domain.ValueObjects
{
    public class Price
    {
        public decimal Valor { get; private set; }
        public string Currency { get; private set; }

        public Price(decimal valor, string currency)
        {
            if (valor <= 0)
                throw new ArgumentException("Price is required");

            Valor = valor;
            Currency = currency ?? throw new ArgumentException(nameof(currency));
        }
    }
}