using Factory_Pattern_First_Look.Business.Models.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Factories
{
    public abstract class ShippingProviderFactory
    {
        public abstract ShippingProvider CreateShippingProvider(string country);
        public  ShippingProvider GetShippingProvider(string country)
        {
            return CreateShippingProvider(country);
        }
    }
}