using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    // Класс заказ в котором список позиций доступен только для чтения
    public class Order
    {
        // Создаем лист с позициями (меню), которое доступно только для чтения
        readonly List<OrderItem> _items = new();
        public IReadOnlyList<OrderItem> Items => _items;
        public PaymentType PaymentType { get; }
        public OrderStatus Status { get; private set; }

        public Order(PaymentType paymentType, OrderStatus status = OrderStatus.New)
        {
            PaymentType = paymentType;
            Status = status;
        }

        public bool IsEmpty => _items.Count == 0;

        public void AddItem(OrderItem item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }
    }
}
