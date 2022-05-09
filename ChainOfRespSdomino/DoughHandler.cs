using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfRespSdomino
{
    public class DoughHandler : PriceFiller
    {
        public DoughHandler(IPriceManager priceManager)
            : base(priceManager) { }

        public override void ProcessPrice(Pizza pizza)
        {
            pizza.Impasto.Ammount = _priceManager.GetPrice(pizza.Impasto.ItemName);
            _next?.ProcessPrice(pizza);
        }
    }
}
