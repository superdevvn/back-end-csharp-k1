using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace SampleConsole
{
    class Program
    {
        static void Init(List<Product> products, List<Order> orders, List<Customer> customers)
        {
            Customer customer = new Customer();
            customer.Name = "Emily";
            customer.Address = "Thanh Da";
            customers.Add(customer);

            customer = new Customer();
            customer.Name = "Peter";
            customer.Address = "13 Ca Van Thinh, P.11, Q.Tan Binh";
            customers.Add(customer);

            Product product = new Product();
            product.Code = "ASUS";
            product.Name = "Laptop ASUS";
            product.Price = 15000000;
            products.Add(product);

            product = new Product();
            product.Code = "DELL";
            product.Name = "Laptop DELL";
            product.Price = 21000000;
            products.Add(product);

            Order order = new Order();
            order.ProductId = products[0].Id;
            order.CustomerId = customers[0].Id;
            order.Quantity = 5;
            orders.Add(order);

            order = new Order();
            order.ProductId = products[1].Id;
            order.CustomerId = customers[0].Id;
            order.Quantity = 2;
            orders.Add(order);

            order = new Order();
            order.ProductId = products[0].Id;
            order.CustomerId = customers[1].Id;
            order.Quantity = 6;
            orders.Add(order);

            order = new Order();
            order.ProductId = products[1].Id;
            order.CustomerId = customers[1].Id;
            order.Quantity = 3;
            orders.Add(order);

            order = new Order();
            order.ProductId = products[1].Id;
            order.CustomerId = customers[0].Id;
            order.Quantity = 7;
            orders.Add(order);
        }

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();
            List<Customer> customers = new List<Customer>();
            Init(products, orders, customers);
            GroupBy(products, orders, customers);
            //Console.WriteLine(SumValue(products, orders, customers));
        }

        static decimal SumValue(List<Product> products, List<Order> orders, List<Customer> customers)
        {
            var orderComplexes = orders
                .Select(order =>
                {
                    var product = products.FirstOrDefault(p => p.Id == order.ProductId);
                    var customer = customers.FirstOrDefault(c => c.Id == order.CustomerId);
                    return new
                    {
                        OrderId = order.Id,
                        CustomerName = customer.Name,
                        CustomerAddress = customer.Address,
                        ProductId = order.ProductId,
                        ProductCode = product.Code,
                        ProductName = product.Name,
                        ProductPrice = product.Price,
                        Quantity = order.Quantity
                    };
                });

            foreach (var orderComplex in orderComplexes)
            {
                Console.WriteLine(string.Format("OrderId: {0}", orderComplex.OrderId));
                Console.WriteLine(string.Format("CustomerName: {0}", orderComplex.CustomerName));
                Console.WriteLine(string.Format("CustomerAddress: {0}", orderComplex.CustomerAddress));
                Console.WriteLine(string.Format("ProductId: {0}", orderComplex.ProductId));
                Console.WriteLine(string.Format("ProductCode: {0}", orderComplex.ProductCode));
                Console.WriteLine(string.Format("ProductName: {0}", orderComplex.ProductName));
                Console.WriteLine(string.Format("ProductPrice: {0}", orderComplex.ProductPrice));
                Console.WriteLine(string.Format("Quantity: {0}", orderComplex.Quantity));
                Console.WriteLine("*********************************");
            }
            return orderComplexes
                .Select(entity => entity.ProductPrice * entity.Quantity)
                .Sum();
        }

        static void GroupBy(List<Product> products, List<Order> orders, List<Customer> customers)
        {
            var orderComplexes = orders
                .Select(order =>
                {
                    var product = products.FirstOrDefault(p => p.Id == order.ProductId);
                    var customer = customers.FirstOrDefault(c => c.Id == order.CustomerId);
                    return new
                    {
                        OrderId = order.Id,
                        CustomerName = customer.Name,
                        CustomerAddress = customer.Address,
                        ProductId = order.ProductId,
                        ProductCode = product.Code,
                        ProductName = product.Name,
                        ProductPrice = product.Price,
                        Quantity = order.Quantity
                    };
                });
            var cus = orderComplexes
                .Select(entity => new
                {
                    CustomerName = entity.CustomerName,
                    SingleValue = entity.ProductPrice * entity.Quantity
                }).GroupBy(entity => entity.CustomerName)
                .Select(entity =>
                new
                {
                    CustomerName = entity.Key,
                    TotalValue = entity.Sum(e => e.SingleValue)
                });
            foreach (var customer in cus)
            {
                Console.WriteLine(string.Format("{0}: {1}", customer.CustomerName, customer.TotalValue));
            }
            //.Select(entity => entity.ProductPrice * entity.Quantity)                
            //.Sum();
        }

        //static decimal SumValue(List<Product> products, List<Order> orders, List<Customer> customers,string customerName)
        //{

        //}
    }
}
