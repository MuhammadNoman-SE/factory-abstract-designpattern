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
        private readonly IPurchaseProviderFactory purchaseProviderFactory;

        public ShoppingCart(Order order, IPurchaseProviderFactory purchaseProviderFactory)
        {
            this.order = order;
            this.purchaseProviderFactory = purchaseProviderFactory;
        }

        public string Finalize()    
        {

            ShippingProvider shippingProvider = purchaseProviderFactory.CreateShippingProvider(order.Sender.Country);
            var invoice = purchaseProviderFactory.CreateInvoice(order);

            // Send invoice

            invoice.GenerateInvoice();

            var summary = purchaseProviderFactory.CreateSummary(order);

            summary.Send();

            // Send summary

			order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
