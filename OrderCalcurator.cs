using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class OrderCalcurator
    {
        public decimal CalculateTotal(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (order.IsEmpty) throw new InvalidOperationException("Невозможно посчитать пустой заказ");
            decimal total = 0m;
            foreach (var item in order.Items)
            {
                total += item.Price;
            }

            // switch (замена if-else) кострукция ветвления (выбора). Помогает выбрать именно нужный нам вариант решения
            return order.PaymentType switch
            {
                //m означает то что число имеет тип decimal и при вводе, например 0.2 выведет не 0.200000, а именно 0.2
                PaymentType.Cash => total + total * 0.05m,
                PaymentType.Card => total + 0.5m,
                // _ => означает, чтобы проверить все остальные случаи, неизвестные и не описанные нами
                PaymentType.Bonus => total >100m ? total - 5m:total,_ => throw new NotSupportedException($"Неизвестный тип оплаты: {order.PaymentType}")
            };
        }
    }
}
