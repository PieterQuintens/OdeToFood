using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants=new List<Restaurant>
            {
                new Restaurant{Id = 1, Name = "Pxl's Pizza Place."},
                new Restaurant{Id = 2, Name = "Tersiguals"},
                new Restaurant{Id = 3, Name = "King's Contrivance"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            // Ascending order by default 
            // (not threadsafe)
            return _restaurants.OrderBy(r => r.Name);
        }
    }
}
