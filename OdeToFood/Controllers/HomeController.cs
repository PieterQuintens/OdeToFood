﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using IRestaurantData = OdeToFood.Data.Interfaces.IRestaurantData;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            //var model = new Restaurant
            //{
            //    Id = 1,
            //    Name = "Pxl's Pizza Place"
            //};

            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.getMessageOfTheDay();

            //return new ObjectResult(model);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;

                newRestaurant = _restaurantData.Add(newRestaurant);

                return RedirectToAction("Details", new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
            
        }
    }
}
