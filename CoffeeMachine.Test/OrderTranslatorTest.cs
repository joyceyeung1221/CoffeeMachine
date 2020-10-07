using System;
using Xunit;

namespace CoffeeMachine.Test
{
    public class OrderTranslatorTest
    {

        [Theory]
        [InlineData("Tea",1,"T:1:0")]
        [InlineData("Coffee",0,"T: :")]
        public void ShouldReturnAString(string item, int num, string expected)
        {
            var protocol = new DrinkMarkerProtocol();
            var orderTranslator = new OrderTranslator(protocol);
            var customerOrder = new CustomerOrder(item, num);
            var result = orderTranslator.ProcessOrder(customerOrder);

            Assert.IsType<string>(result);
        }
    }
}
