using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Factories
{
    public class GlobalShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order)
        {
            return "Global-Express";
        }
    }
}
