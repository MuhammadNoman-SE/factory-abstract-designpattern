using Factory_Pattern_First_Look.Business;
using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Factories;
using Factory_Pattern_First_Look.Factory;
using System;

namespace Factory_Pattern_First_Look
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create Order
            Console.Write("Recipient Country: ");
            var recipientCountry = Console.ReadLine().Trim();

            Console.Write("Sender Country: ");
            var senderCountry = Console.ReadLine().Trim();

            Console.Write("Total Order Weight: ");
            var totalWeight = Convert.ToInt32(Console.ReadLine().Trim());

            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Filip Ekberg",
                    Country = recipientCountry
                },

                Sender = new Address
                {
                    To = "Someone else",
                    Country = senderCountry
                },

                TotalWeight = totalWeight
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m), 1);
            #endregion

            IPurchaseProviderFactory purchaseProviderFactory;

            if(order.Sender.Country == "Sweden")
            {
                purchaseProviderFactory = new SwedishPostalServiceShippingProviderFactory();
            }
            else if (order.Sender.Country == "Australia")
            {
                purchaseProviderFactory = new AustraliaPostShippingProviderFctory();
            }
            else
            {
                throw new NotSupportedException("Sender country has no purchase provider");
            }

            var cart = new ShoppingCart(order, purchaseProviderFactory);

            var shippingLabel = cart.Finalize();

            Console.WriteLine(shippingLabel);
        }
    }
}
