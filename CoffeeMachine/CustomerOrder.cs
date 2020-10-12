using System;
namespace CoffeeMachine
{
    public class CustomerOrder
    {
        public Enum Item { get; private set; }
        public int NumOfSugar { get; private set; }
        public Enum Temputure { get; private set; }

        public CustomerOrder(Enum item, int numOfSugar = 0, int temputure = (int)DrinkTemputure.Normal)
        {
            Item = item;
            NumOfSugar = numOfSugar;
            Temputure = (DrinkTemputure)temputure;
        }
    }
}
