using FoodKart.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodKart.RestaurantSelection
{
    public class HighestRatedRestaurantSelection : IRestaurantSelection
    {
        public Restaurant SelectRestaurant(List<Restaurant> eligibleRestaurants, Order order)
        {
            return eligibleRestaurants.OrderByDescending(r => r.Rating).FirstOrDefault();
        }
    }
}
