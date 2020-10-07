using System;
namespace CoffeeMachine
{
    public class OrderTranslator
    {
        private DrinkMarkerProtocol _protocol;
        public OrderTranslator(DrinkMarkerProtocol drinkMarkerProtocol)
        {
            _protocol = drinkMarkerProtocol;
        }

        public string ProcessOrder(CustomerOrder customerOrder)
        {
            var firstElement = _protocol.GetFirstElement(customerOrder.Item);
            var secondElement = _protocol.GetSecondElement(customerOrder.NumOfSugar);
            var thirdElement = _protocol.GetThirdElement(customerOrder.NumOfSugar);

            return $"{firstElement}:{secondElement}:{thirdElement}";
        }
    }
}
