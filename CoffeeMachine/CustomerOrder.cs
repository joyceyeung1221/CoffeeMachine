using System;
namespace CoffeeMachine
{
    public class CustomerOrder
    {
        public string Item { get; private set; }
        public int NumOfSugar { get; private set; }
        public string Message { get; private set; }

        public CustomerOrder(string item, int numOfSugar, string message="")
        {
            Item = item;
            NumOfSugar = numOfSugar;
            Message = message;
        }
    }
}
