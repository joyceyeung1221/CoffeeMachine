using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class DrinkMarkerProtocol
    {
        public DrinkMarkerProtocol()
        {
        }

        private Dictionary<Enum, string> itemList = new Dictionary<Enum, string>()
        {   
            {Drink.Tea, "T" },
            {Drink.Chocolate, "H" },
            {Drink.Coffee, "C" },
            {Drink.OrangeJuice, "O" }
        };

        public string GetFirstElement(Enum item, Enum temputure)
        {
            var output = itemList[item];
            if (temputure.Equals(DrinkTemputure.Hot))
            {
                output += "h";
            }
            return output;
        }


        public string GetSecondElement(int numOfSugar)
        {
            if (numOfSugar > 0)
            {
                return numOfSugar.ToString();
            }
            return "";
        }

        public string GetThirdElement(int numOfSuger)
        {
            if(numOfSuger!= 0)
            {
                return "0";
            }
            return "";
        }
    }
}
