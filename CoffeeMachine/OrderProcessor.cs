using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class OrderProcessor
    {
        private OrderTranslator _translator;
        private PriceList _priceList;
        private SalesRegister _salesRegister;
        private EmailNotifier _notifier;
        private BeverageQuantityChecker _checker;

        public OrderProcessor(PriceList priceList, SalesRegister salesRegister, EmailNotifier emailNotifier, BeverageQuantityChecker checker)
        {
            _translator = new OrderTranslator(new DrinkMarkerProtocol());
            _priceList = priceList;
            _salesRegister = salesRegister;
            _notifier = emailNotifier;
            _checker = checker;
        }

        public string HandleOrder(CustomerOrder order, decimal payment)
        {
            if (!IsSufficientPayment(order, payment))
            {
                var shortfall = _priceList.Drinks[order.Item] - payment;
                return _translator.ConvertMessage(shortfall);
            }
            if (_checker.isEmpty(order.Item.ToString()))
            {
                _notifier.NotifyMissingDrink(order.Item.ToString());
                return _translator.ConvertMessage(order.Item.ToString());
            }
            _salesRegister.AddSales(order.Item);
            return _translator.TranslateOrder(order);
        }

        private bool IsSufficientPayment(CustomerOrder order, decimal payment)
        {
            return payment >= _priceList.Drinks[order.Item];
        }

    }
}
