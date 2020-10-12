using System;
using Xunit;
using Moq;


namespace CoffeeMachine.Test
{
    public class OrderProcessorTest
    {
        private OrderProcessor orderProcessor;
        private SalesData salesData;
        private PriceList priceList;
        private SalesRegister salesRegister;
        private Mock<EmailNotifier> mockNotifier;
        private Mock<BeverageQuantityChecker> mockChecker;
        public OrderProcessorTest()
        {
            priceList = new PriceList();
            salesData = new SalesData();
            salesRegister = new SalesRegister(salesData, priceList);
            mockNotifier = new Mock<EmailNotifier>();
            mockChecker = new Mock<BeverageQuantityChecker>();
            orderProcessor = new OrderProcessor(priceList, salesRegister, mockNotifier.Object, mockChecker.Object);
        }


        [Theory]
        [InlineData(Drink.Tea, 1, "T:1:0", 0.4)]
        [InlineData(Drink.Tea, 0, "M:You are 0.2 euro short.", 0.2)]
        public void ShouldReturnAString(Enum item, int num, string expected, decimal payment)
        {
            var customerOrder = new CustomerOrder(item, num);
            var result = orderProcessor.HandleOrder(customerOrder, payment);

            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(Drink.Tea, 1, 1, 0.4)]
        [InlineData(Drink.Tea, 0, 0, 0.2)]
        public void ShouldIncreaseNumberOfDrinks_WhenPaymentIsSufficientForTeaOrder(Enum item, int num, int expected, decimal payment)
        {
            var customerOrder = new CustomerOrder(item, num);
            var result = orderProcessor.HandleOrder(customerOrder, payment);

            Assert.True(salesData.Tea == expected);
        }

        [Theory]
        [InlineData(Drink.Coffee, 1, 1, 0.6, 0.6)]
        [InlineData(Drink.Coffee, 0, 0, 0.2, 0)]
        public void ShouldIncreaseNumberOfDrinks_WhenPaymentIsSufficientForCoffeeOrder(Enum item, int num, int expected, decimal payment, decimal expectedTotalSales)
        {
            var customerOrder = new CustomerOrder(item, num);
            var result = orderProcessor.HandleOrder(customerOrder, payment);

            Assert.True(salesData.Coffee == expected);
            Assert.True(salesData.TotalSales == expectedTotalSales);
        }

        [Fact]
        public void ShouldCallEmailNotifier_WhenDrinkIsLow()
        {
            mockNotifier = new Mock<EmailNotifier>();
            mockChecker = new Mock<BeverageQuantityChecker>();
            mockChecker.Setup(x => x.isEmpty(It.IsAny<string>())).Returns(true);
            orderProcessor = new OrderProcessor(priceList, salesRegister, mockNotifier.Object, mockChecker.Object);
            var customerOrder = new CustomerOrder(Drink.Tea, 0);
            var result = orderProcessor.HandleOrder(customerOrder, (decimal)0.5);

            mockNotifier.Verify(x => x.NotifyMissingDrink(It.IsAny<string>()), Times.Once);

        }
    }
}
