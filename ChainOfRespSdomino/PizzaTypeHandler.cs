using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfRespSdomino
{
    public class PizzaTypeHandler : PriceFiller
    {
        public PizzaTypeHandler(IPriceManager priceManager)
            : base(priceManager) { }

        public override void ProcessPrice(Pizza pizza)
        {
            pizza.TipoPizza.Ammount = _priceManager.GetPrice(pizza.TipoPizza.ItemName);
            _next?.ProcessPrice(pizza);
        }
    }
}
