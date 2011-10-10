using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MobWars.Test.Unit.AutoMapper
{
    public class Customer
    {
        private readonly IList<Order> orders = new List<Order>();
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        public IList<Order> Orders
        {
            get { return new ReadOnlyCollection<Order>(orders); }
        }

        public void Order(int qty, Product product)
        {
            orders.Add(new Order(qty, product));
        }
    }

    public class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Order
    {
        public int Qty { get; private set; }
        public Product Product { get; private set; }

        public Order(int qty, Product product)
        {
            Qty = qty;
            Product = product;
        }

        public double Price
        {
            get { return Qty*Product.Price; }
        }
    }
}