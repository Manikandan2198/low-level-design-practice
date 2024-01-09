using System.Collections.Generic;

namespace FoodKart
{
    public interface IRestaurantSelection
    {
        public Restaurant SelectRestaurant(List<Restaurant> eligibleRestaurants, Order order);
    }
}