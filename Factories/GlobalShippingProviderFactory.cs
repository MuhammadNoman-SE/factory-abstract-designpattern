using Factory_Pattern_First_Look.Business.Models.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Factories
{
    public class GlobalShippingProviderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalShippingProvider();
        }
    }
}
