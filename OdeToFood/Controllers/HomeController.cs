﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            //var model = new Restaurant
            //{
            //    Id = 1,
            //    Name = "Pxl's Pizza Place"
            //};

            var model = _restaurantData.GetAll();

            //return new ObjectResult(model);
            return View(model);
        }
    }
}
