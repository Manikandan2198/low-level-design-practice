using FoodKart.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodKart
{
    public class Restaurant
    {
        public String Name { get; }
        public Dictionary<String,Item> Menu { get; }
        public int Capacity { get; }
        private List<Order> CurrentOrders { get; }
        public double Rating { get; }

        public Restaurant(String name, List<Item> menu, int capacity, double rating)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Rating = rating;
            this.CurrentOrders = new List<Order>();
            this.Menu = new Dictionary<string, Item>();
            foreach (var item in menu)
            {
                this.Menu.Add(item.ItemName, item);
            }
        }

        public void AcceptOrder(Order order)
        {
            if (IsCapacityFull())
                throw new CapacityLimitReachedException("Restaurant capacity reached");

            if (order.OrderItems.All(i => IsMenuAvailable(i.ItemName)))
                throw new NotFoundException("Some of the item(s) in the order are not served in this restaurant");

            order.Status = Status.ACCEPTED;
            order.Restaurant = this;
            this.CurrentOrders.Add(order);
        }

        public bool IsCapacityFull()
        {
            return this.CurrentOrders.Count == this.Capacity;
        }

        public bool IsMenuAvailable(string itemName)
        {
            return this.Menu.ContainsKey(itemName);
        }

        public void CompleteOrder(int id)
        {
            var order = this.CurrentOrders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                throw new NotFoundException("Order not found in this restaurant");

            order.Status = Status.COMPLETED;
            this.CurrentOrders.Remove(order);
        }

        public void UpdateMenu(string itemName, decimal newPrice)
        {
            if(!Menu.ContainsKey(itemName))
                throw new NotFoundException("Item not found in this restaurant's menu");

            this.Menu[itemName].Price = newPrice;
        }

        public void AddMenu(string itemName, decimal price)
        {
            if (Menu.ContainsKey(itemName))
                throw new AlreadyExistsException("Item already exists in the menu");

            Menu.Add(itemName, new Item { ItemName = itemName, Price = price });
        }
    }
}
