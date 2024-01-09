using FoodKart.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodKart
{
    public class RestaurantManagement
    {
        public List<Restaurant> Restaurants { get; set; }

        public RestaurantManagement()
        {
            this.Restaurants = new List<Restaurant>();
        }

        public void OnBoardRestaurant(Restaurant restaurant)
        {
            this.Restaurants.Add(restaurant);
        }

        public void AssignOrder(Order order, IRestaurantSelection restaurantSelection)
        {
            var orderItemNames = order.OrderItems.Select(oi => oi.ItemName).ToList();
            var capacityFreeRestaurants = this.Restaurants.Where(r => !r.IsCapacityFull()).ToList();
            var eligibleRestaurants = capacityFreeRestaurants.Where(r => orderItemNames.All(i=>r.IsMenuAvailable(i))).ToList();

            var fulfillingRestaurant = restaurantSelection.SelectRestaurant(eligibleRestaurants, order);
            if (fulfillingRestaurant == null)
                throw new NotFoundException("Order can’t be fulfilled");

            fulfillingRestaurant.AcceptOrder(order);
        }
    }
}
