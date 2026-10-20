namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new OrderService();
            RunCode(service);
            static RunCode(OrderService service)
            {
                var order = new Order(PaymentType.Card, OrderStatus.New);
                order.AddItem(new OrderItem("Burger", 5.99m));
                order.AddItem(new OrderItem("Fries", 2.99m));

                service.Process(order);
            }
        }
    }
}
