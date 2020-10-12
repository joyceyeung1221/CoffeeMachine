using System;
using Xunit;

namespace CoffeeMachine.Test
{
    public class OrderTranslatorTest
    {

        [Theory]
        [InlineData(Drink.Tea, 1, "T:1:0")]
        [InlineData(Drink.Coffee, 0, "C::")]
        [InlineData(Drink.OrangeJuice, 0, "O::")]
        public void ShouldReturnAString(Enum item, int num, string expected)
        {
            var protocol = new DrinkMarkerProtocol();
            var orderTranslator = new OrderTranslator(protocol);
            var customerOrder = new CustomerOrder(item, num);
            var result = orderTranslator.TranslateOrder(customerOrder);

            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(Drink.Coffee, 1, (int)DrinkTemputure.Hot, "Ch:1:0")]
        [InlineData(Drink.Chocolate, 0, (int)DrinkTemputure.Normal, "H::")]
        public void ShouldReturnAStringWithHSymbolForHotDrink(Enum item, int num, int temputure, string expected)
        {
            var protocol = new DrinkMarkerProtocol();
            var orderTranslator = new OrderTranslator(protocol);
            var customerOrder = new CustomerOrder(item, num, temputure);
            var result = orderTranslator.TranslateOrder(customerOrder);

            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnAMessageDrinkNotAvailable_WhenPutInNameOfDrink()
        {
            var protocol = new DrinkMarkerProtocol();
            var orderTranslator = new OrderTranslator(protocol);
            var result = orderTranslator.ConvertMessage(Drink.Tea.ToString());

            Assert.IsType<string>(result);
            Assert.Equal("M: Tea is not available. An email has been sent to notify the vendor", result);
        }
    }
}
