using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class DrinkMarkerProtocol
    {
        public DrinkMarkerProtocol()
        {
        }

        private Dictionary<string, string> itemList = new Dictionary<string, string>()
        {
            {"Tea", "T" },
            {"Chocolate", "H" },
            {"Coffee", "C" }
        };

        public string GetFirstElement(string item)
        {
            return itemList[item];
        }

        public string GetSecondElement(int num)
        {
            if (num > 0)
            {
                return num.ToString();
            }
            return " ";
        }

        public string GetThirdElement(int num)
        {
            if(num!= 0)
            {
                return "";
            }
            return "0";
        }
    }
}
