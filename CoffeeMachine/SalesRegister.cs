using System;
using System.Reflection;

namespace CoffeeMachine
{
    public class SalesRegister
    {
        private SalesData _salesData;
        private PriceList _priceList;

        public SalesRegister(SalesData salesData, PriceList priceList)
        {
            _salesData = salesData;
            _priceList = priceList;
        }

        public void AddSales(Enum item)
        {
            AddNumberOfSales(item);
            AddTotalSales(item);
        }

        private void AddNumberOfSales(Enum item)
        {
            switch (item)
            {
                case Drink.Chocolate:
                    _salesData.Chocolate += 1;
                    break;
                case Drink.Coffee:
                    _salesData.Coffee += 1;
                    break;
                case Drink.Tea:
                    _salesData.Tea += 1;
                    break;
                case Drink.OrangeJuice:
                    _salesData.OrangeJuice += 1;
                    break;
                default:
                    break;

            }
        }

        private void AddTotalSales(Enum item)
        {
            _salesData.TotalSales += _priceList.Drinks[item];
        }
    }
}
