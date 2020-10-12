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

        public string TranslateOrder(CustomerOrder customerOrder)
        {
            var firstElement = _protocol.GetFirstElement(customerOrder.Item, customerOrder.Temputure);
            var secondElement = _protocol.GetSecondElement(customerOrder.NumOfSugar);
            var thirdElement = _protocol.GetThirdElement(customerOrder.NumOfSugar);

            return $"{firstElement}:{secondElement}:{thirdElement}";
        }

        public string ConvertMessage(decimal shortfall)
        {
            var messageToCustomer = $"You are {shortfall} euro short.";
            return $"M:{messageToCustomer}";
        }

        public string ConvertMessage(string drink)
        {
            return $"M: {drink} is not available. An email has been sent to notify the vendor";
        }
    }
}
