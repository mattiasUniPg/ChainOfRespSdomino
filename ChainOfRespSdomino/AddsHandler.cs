using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfRespSdomino
{
    public class AddsHandler : PriceFiller
    {
        public AddsHandler(IPriceManager priceManager)
            : base(priceManager) { }

        public override void ProcessPrice(Pizza pizza)
        {
            foreach (var component in pizza.Components)
            {
                component.Ammount = _priceManager.GetPrice(component.ItemName);
            }
            _next?.ProcessPrice(pizza);
        }
    }
}
