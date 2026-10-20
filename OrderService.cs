using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class OrderService
    {
        readonly OrderCalcurator _calculator;
        readonly PrintReceipt _printer;

        public OrderService(OrderCalcurator? calcurator = null, PrintReceipt? printer = null)
        {
            _calculator = calcurator ?? new OrderCalcurator();
            _printer = printer ?? new PrintReceipt();
        }
        public bool Process(Order order)
        {
            if (order is null)
            {
                Console.WriteLine("Ошибка: заказ пустой");
                return false;
            }
            if (order.IsEmpty)
            {
                Console.WriteLine("Ошибка: заказ пустой");
                return false;
            }
            decimal total;
            try
            {
                total = _calculator.CalculateTotal(order);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return false;
            }
            PrintStatus(order.Status);
            _printer.Print(order, total);
            return true;

        }
        
        static void PrintStatus(OrderStatus status)
        {
            switch (status)
            {
                // case, default конкретный и запасной вариант события switch
                case OrderStatus.New:
                    Console.WriteLine("Order accepted");
                    break;
                case OrderStatus.Cooking:
                    Console.WriteLine("Cooking...");
                    break;
                case OrderStatus.Ready:
                    Console.WriteLine("Ready for pickup");
                    break;
                case OrderStatus.Done:
                    Console.WriteLine("Already given");
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(status), $"Неизвестный статус: {status}");
            }
        }
    }
}
