using Abstract_Factory_Pattern.Business.Models.Commerce.Invoice;
using Abstract_Factory_Pattern.Business.Models.Commerce.Summary;
using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using Factory_Pattern_First_Look.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Factories
{
    public interface IPurchaseProviderFactory
    {
         ShippingProvider CreateShippingProvider(string country);
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
    }
    public class AustraliaPostShippingProviderFctory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CreateShippingProvider(string country)
        {
            return new StandardShippingProviderFactory().CreateShippingProvider(country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }

    public class SwedishPostalServiceShippingProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CreateShippingProvider(string country)
        {
            return new StandardShippingProviderFactory().CreateShippingProvider(country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }
}
