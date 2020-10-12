using System;
namespace CoffeeMachine
{
    public class SalesReporter
    {
        private SalesData _salesData;
        public SalesReporter(SalesData salesdata)
        {
            _salesData = salesdata;
        }

        public string GenerateReport()
        {
            var report =
                $"Coffee: {_salesData.Coffee}\n" +
                $"Tea: {_salesData.Tea}\n" +
                $"Hot Chocolate: {_salesData.Chocolate}\n" +
                $"Orange Juice: {_salesData.OrangeJuice}\n" +
                $"\n" +
                $"Total Sales: ${_salesData.TotalSales.ToString("F")}";
            return report;
        }
    }
}
