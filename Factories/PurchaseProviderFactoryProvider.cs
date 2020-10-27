using Factory_Pattern_First_Look.Business.Models.Shipping;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
namespace Factory_Pattern_First_Look.Factories
{
    public class PurchaseProviderFactoryProvider
    {
        private IEnumerable<Type> factories;

        public PurchaseProviderFactoryProvider()
        {
            factories = Assembly.GetAssembly(typeof(PurchaseProviderFactoryProvider))
             .GetTypes()
             .Where(t => typeof(IPurchaseProviderFactory)
             .IsAssignableFrom(t));

        }
        public IPurchaseProviderFactory CreateFactory(string name)
        {
            var factory = factories
        .Single(x => x.Name.ToLowerInvariant()
        .Contains(name.ToLowerInvariant()));

            var instance =
                (IPurchaseProviderFactory)Activator
                .CreateInstance(factory);
            return instance;
        }
    }
}
