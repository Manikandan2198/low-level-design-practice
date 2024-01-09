using FoodKart.Exceptions;
using System;
using System.Collections.Generic;

namespace FoodKart
{
    public class Order
    {
        public int Id { get; }
        public String User { get; }
        public List<OrderItem> OrderItems { get; }
        public Restaurant Restaurant { get; set; }
        public Status Status
        {
            get { return Status; }
            set
            {
                if ((Status == Status.CREATED && value != Status.ACCEPTED) ||
                    (Status == Status.ACCEPTED && value != Status.COMPLETED) ||
                    Status == Status.COMPLETED)
                {
                    throw new InvalidOrderStatusException("Order status invalid");
                }

                Status = value;
            }
        }

        public Order(int id,string user, List<OrderItem> orderItems)
        {
            this.Id = id;
            this.User = user;
            this.OrderItems = orderItems;
            this.Status = Status.CREATED;
        }

    }


    public enum Status
    {
        CREATED,
        ACCEPTED,
        COMPLETED
    }

    public class OrderItem
    {
        public string ItemName { get; }
        public int Quantity { get; }

        public OrderItem(string itemName, int quantity)
        {
            this.ItemName = itemName;
            this.Quantity = quantity;
        }
    }
}