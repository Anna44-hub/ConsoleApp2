using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class PrintReceipt
    {
        public void Print(Order order, decimal total)
        {
            if (order is null) throw new ArgumentNullException(nameof(order));
            Console.WriteLine("----Receipt----");

            foreach (var item in order.Items)
            {
                Console.WriteLine($"{item.Name} - {item.Price:0.00}");
            }
            Console.WriteLine($"Total: {total:0.00}");
            Console.WriteLine($"Payment: {order.PaymentType}");
            Console.WriteLine($"Status: {order.Status}");
        }
    }
}
