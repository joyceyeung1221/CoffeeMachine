using System;
namespace CoffeeMachine
{
    public interface EmailNotifier
    {
        public void NotifyMissingDrink(String drink);
    }
}
