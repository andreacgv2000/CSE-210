using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear direcciones
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Crear clientes
        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("Bob Smith", address2);

        // Crear productos
        Product prod1 = new Product("Laptop", "LAP123", 1200.00, 1);
        Product prod2 = new Product("Mouse", "MOU456", 25.50, 2);
        Product prod3 = new Product("Keyboard", "KEY789", 45.00, 1);
        Product prod4 = new Product("Monitor", "MON321", 300.00, 2);

        // Crear órdenes
        Order order1 = new Order(customer1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        Order order2 = new Order(customer2);
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);

        List<Order> orders = new List<Order> { order1, order2 };

        // Mostrar resultados
        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}\n");
            Console.WriteLine("---------------------------\n");
        }
    }
}
