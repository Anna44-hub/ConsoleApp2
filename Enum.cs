using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    // enum - это пользовательский тип данных, который представляет собой набор именнованный констант, которые помогают нам заменить магические строки/числа на понятные имена
    // Тип оплаты
    public enum PaymentType
    {
        Cash,
        Card,
        Bonus
    }

    // Статус заказа
    public enum OrderStatus
    {
        New,
        Cooking,
        Ready,
        Done
    }
}
