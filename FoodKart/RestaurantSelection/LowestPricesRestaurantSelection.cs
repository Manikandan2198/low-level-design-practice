using FoodKart.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodKart.RestaurantSelection
{
    public class LowestPricesRestaurantSelection : IRestaurantSelection
    {
        public Restaurant SelectRestaurant(List<Restaurant> eligibleRestaurants, Order order)
        {
            decimal minPrice = decimal.MaxValue;
            Restaurant minPriceRestaurant = null;
            foreach (var restaurant in eligibleRestaurants)
            {
                decimal restaurantPrice = 0;
                foreach (var item in order.OrderItems)
                {
                    if (!restaurant.Menu.ContainsKey(item.ItemName))
                        throw new NotFoundException("Invalid state exception");

                    var restaurantMenuItem = restaurant.Menu[item.ItemName];
                    restaurantPrice += restaurantMenuItem.Price * item.Quantity;
                }

                if (restaurantPrice < minPrice)
                {
                    minPrice = restaurantPrice;
                    minPriceRestaurant = restaurant;
                }

            }

            return minPriceRestaurant;
        }
    }
}
