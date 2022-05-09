using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfRespSdomino
{
    public interface IPriceManager
    {
        decimal GetPrice(string itemName);
    }

    public static class PriceManagerFactory
    {
        private static Dictionary<string, decimal> doughPriceList =
            new Dictionary<string, decimal>()
            {
                { "integrale", 1.0M }
            };

        private static Dictionary<string, decimal> addsPriceList =
            new Dictionary<string, decimal>()
            {
                        { "capperi", 1.0M },
                        { "olive", 1.0M },
                        { "ananas", 50.0M }
            };

        private static Dictionary<string, decimal> PizzaTypePriceList =
            new Dictionary<string, decimal>()
            {
                                { "margherita", 5.0M },
                                { "marinara", 6.0M },
                                { "capricciosa", 7.0M }
            };

        public static IPriceManager GetPriceManager(Type type)
        {
            switch (type.GetType().Name)
            {
                case "DoughHandler":
                    return new PriceManager(doughPriceList);
                case "AddsHandler":
                    return new PriceManager(addsPriceList);
                case "PizzaTypeHandler":
                    return new PriceManager(PizzaTypePriceList);
            }
            throw new ArgumentOutOfRangeException("This handler is not managed!");
        }
    }

    public class PriceManager : IPriceManager
    {
        private Dictionary<string, decimal> _priceList;
        public PriceManager(Dictionary<string, decimal> priceList)
        {
            _priceList = priceList;
        }

        public decimal GetPrice(string itemName)
        {
            if (_priceList.TryGetValue(itemName, out decimal price))
            {
                return price;
            }
            throw new ArgumentException("there is no price for this element!", nameof(itemName));
        }
    }
}
