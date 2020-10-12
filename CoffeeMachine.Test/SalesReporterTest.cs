using System;
using Xunit;
using Moq;

namespace CoffeeMachine.Test
{
    public class SalesReporterTest
    {
        public SalesReporterTest()
        {
        }

        [Fact]
        public void ShouldPrintSalesReport()
        {
            var salesData = new SalesData();
            salesData.Coffee = 1;
            salesData.TotalSales = (decimal)0.60;
            var salesReporter = new SalesReporter(salesData);
            var result = salesReporter.GenerateReport();

            Assert.Equal("Coffee: 1\nTea: 0\nHot Chocolate: 0\nOrange Juice: 0\n\nTotal Sales: $0.60", result);
        }

        [Fact]
        public void ShouldPrintSalesReportCapturingAllValidSales()
        {
            var priceList = new PriceList();
            var salesData = new SalesData();
            var salesRegister = new SalesRegister(salesData, priceList);
            var mockNotifier = new Mock<EmailNotifier>();
            var mockChecker = new Mock<BeverageQuantityChecker>();
            var orderProcessor = new OrderProcessor(priceList, salesRegister, mockNotifier.Object, mockChecker.Object);
            var customerOrder = new CustomerOrder(Drink.OrangeJuice);
            var customerOrder1 = new CustomerOrder(Drink.Coffee, temputure: (int)DrinkTemputure.Hot);
            var customerOrder2 = new CustomerOrder(Drink.Chocolate, 2);
            var customerOrder3 = new CustomerOrder(Drink.Tea, 2);
            orderProcessor.HandleOrder(customerOrder, (decimal)0.60);
            orderProcessor.HandleOrder(customerOrder1, (decimal)0.60);
            orderProcessor.HandleOrder(customerOrder2, (decimal)0.20);
            orderProcessor.HandleOrder(customerOrder3, (decimal)0.60);
            var salesReporter = new SalesReporter(salesData);
            var result = salesReporter.GenerateReport();

            Assert.Equal("Coffee: 1\nTea: 1\nHot Chocolate: 0\nOrange Juice: 1\n\nTotal Sales: $1.60", result);
        }


    }
}
