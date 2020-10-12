using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class PriceList
    {
        public Dictionary<Enum, decimal> Drinks;

        public PriceList()
        {
            Drinks = new Dictionary<Enum, decimal>
            {
                {Drink.Tea, (decimal)0.40 },
                {Drink.Coffee, (decimal)0.60 },
                {Drink.Chocolate, (decimal)0.50 },
                {Drink.OrangeJuice, (decimal)0.60 }
            };
        }
    }
}
