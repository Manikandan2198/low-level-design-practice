using NUnit.Framework;
using System.Collections.Generic;
using FoodKart.Exceptions;

namespace FoodKart.UnitTests
{
    public class RestaurantTests
    {
        private Restaurant restaurant;
        [SetUp]
        public void Setup()
        {
            var r1Menu = new List<Item>() { new Item() { ItemName = "Veg Biryani", Price = 100 }, new Item() { ItemName = "Paneer Butter Masala", Price = 150 } };
            restaurant = new Restaurant("R1", r1Menu, 1, 4.5);
        }

        [Test]
        public void AddMenu_AddExistingMenu_ThrowsAlreadyExistsException()
        {
            Assert.That(() => restaurant.AddMenu("Veg Biryani", 120), Throws.TypeOf<AlreadyExistsException>());
            
        }

        [Test]
        public void AddMenu_AddNonExistingMenu_MenuAdded()
        {
            restaurant.AddMenu("Idli", 10);
            Assert.That(restaurant.Menu.ContainsKey("Idli"), Is.True);
        }

        [Test]
        public void UpdateMenu_UpdateNonExistingMenu_ThrowsNotFoundException()
        {
            Assert.That(() => restaurant.UpdateMenu("Idli", 10), Throws.TypeOf<NotFoundException>());
        }

        [Test]
        public void UpdateMenu_UpdateExistingMenu_MenuUpdated()
        {
            restaurant.UpdateMenu("Paneer Butter Masala", 175);
            Assert.That(restaurant.Menu["Paneer Butter Masala"].Price, Is.EqualTo(175));
        }

        [Test]
        public void AcceptOrder_PlaceOrderWhenCapacityFull_ThrowCapacityLimitReachedExceptionException()
        {
            var orderItems = new List<OrderItem>() { new OrderItem("Veg Biryani", 2) };
            restaurant.AcceptOrder(new Order(1, "Mani", orderItems));

            var newOrderItems = new List<OrderItem>() { new OrderItem("Veg Biryani", 1) };
            Assert.That(() => restaurant.AcceptOrder(new Order(2, "MK", newOrderItems)), Throws.TypeOf<CapacityLimitReachedException>());
        }

        [Test]
        public void AcceptOrder_PlaceOrderWithNonExistingItem_ThrowsNotFoundException()
        {
            var orderItems = new List<OrderItem>() { new OrderItem("Paneer Butter Masala", 3) };

            Assert.That(() => restaurant.AcceptOrder(new Order(1, "Mani", orderItems)), Throws.TypeOf<NotFoundException>());
        }

        [Test]
        public void AcceptOrder_PlaceOrderWithExistingItemsAndCapacityFree_AcceptsOrder()
        {
            var orderItems = new List<OrderItem>() { new OrderItem("Veg Biryani", 3) };
            var order = new Order(1, "Mani", orderItems);
            restaurant.AcceptOrder(order);

            Assert.That(order.Restaurant.Name, Is.EqualTo("R1"));
        }

        [Test]
        public void CompleteOrder_CompleteNonExistingOrder_NotFoundException()
        {
            var orderItems = new List<OrderItem>() { new OrderItem("Veg Biryani", 3) };
            var order = new Order(1, "Mani", orderItems);
            restaurant.AcceptOrder(order);

            Assert.That(() => restaurant.CompleteOrder(2), Throws.TypeOf<NotFoundException>());
        }

        [Test]
        public void CompleteOrder_CompleteExistingOrder_CpmpletedStatusUpdated()
        {
            var orderItems = new List<OrderItem>() { new OrderItem("Veg Biryani", 3) };
            var order = new Order(1, "Mani", orderItems);
            restaurant.AcceptOrder(order);
            restaurant.CompleteOrder(1);
            Assert.That(order.Status, Is.EqualTo(Status.COMPLETED));
        }

        [Test]
        [TestCase("Veg Biryani",true)]
        [TestCase("Paneer Butter Masala", false)]
        public void IsMenuAvailable_check(string itemName, bool expected)
        {
            Assert.That(restaurant.IsMenuAvailable(itemName), Is.EqualTo(expected));
        }

        public void IsCapacityFull_AddOrdersEqualToCapacity_ReturnsTrue()
        {
            var orderItems = new List<OrderItem>() { new OrderItem("Veg Biryani", 2) };
            restaurant.AcceptOrder(new Order(1, "Mani", orderItems));

            var newOrderItems = new List<OrderItem>() { new OrderItem("Veg Biryani", 1) };
            restaurant.AcceptOrder(new Order(2, "MK", newOrderItems));

            Assert.That(restaurant.IsCapacityFull(), Is.True);
        }

        public void IsCapacityFull_AddOrdersLessThanCapacity_ReturnsFalse()
        {
            var orderItems = new List<OrderItem>() { new OrderItem("Veg Biryani", 2) };
            restaurant.AcceptOrder(new Order(1, "Mani", orderItems));

            Assert.That(restaurant.IsCapacityFull(), Is.False);
        }

    }
}