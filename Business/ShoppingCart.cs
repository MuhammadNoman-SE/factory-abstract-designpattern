using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using Factory_Pattern_First_Look.Factory;
using System;

namespace Factory_Pattern_First_Look.Business
{
    public class ShoppingCart
    {
        private readonly Order order;

        public ShoppingCart(Order order)
        {
            this.order = order;
        }

        public string Finalize()    
        {

            ShippingProvider shippingProvider = ShippingProviderFactory.CreateShippingProvider(order.Sender.Country);
            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
