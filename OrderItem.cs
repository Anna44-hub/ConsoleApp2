using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class OrderItem
    {
        public string Name { get; }
        public decimal Price { get; }

        public OrderItem(string name, decimal price)
        {
            // Обработка ошибок в заказе (указано ли название и не отрицательная ли цена), если да то оператор throw останавливает работу кода и указывает на ошибку
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Обязательно укажите название блюда в заказе", nameof(name));
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), "Цена не может быть отрицательной");
            
            // .Trim метод типа string, который удаляет пробелы с начала и конца строки и возвращает новую строку
            Name = name.Trim();
            Price = price;
        }

        // override - класс который можно переопределить
        // Отображение информации об объекте в формате строки
        // Отображение названия блюда и цены в Окне
        public override string ToString() => $"{Name} - {Price: 0.00}";
    }
}
