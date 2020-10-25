using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using Factory_Pattern_First_Look.Factories;
using Factory_Pattern_First_Look.Factory;
using System;

namespace Factory_Pattern_First_Look.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private ShippingProviderFactory shippingProviderFactory;

        public ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory)
        {
            this.order = order;
            this.shippingProviderFactory = shippingProviderFactory;
        }

        public string Finalize()    
        {

            ShippingProvider shippingProvider = shippingProviderFactory.CreateShippingProvider(order.Sender.Country);
            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
