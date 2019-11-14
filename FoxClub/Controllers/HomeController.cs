using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoxClub.Models;
using FoxClub.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoxClub.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        FoxService foxservice;

        public HomeController(FoxService foxService)
        {
            this.foxservice = foxService;
        }


        [HttpGet("/")]
        public IActionResult Index(string name)
        {
            if (foxservice.IsLogged(name))
            {
                Fox fox = foxservice.FindFoxByName(name);
                return View(fox);
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(string name)
        {
            foxservice.CreateIfNotExist(name);
            return RedirectToAction("Index", new { name = name });
        }
        [HttpGet("nutritionStore")]
        public IActionResult NutritionStore(string name)
        {
            if (foxservice.IsLogged(name))
            {
                ViewBag.Foods = foxservice.ListOfFoods;
                ViewBag.Drinks = foxservice.ListOfDrinks;

                return View(foxservice.FindFoxByName(name));
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        [HttpPost("nutritionStore")]
        public IActionResult NutritionStore(string food, string drink, string name)
        {
            if (foxservice.IsLogged(name))
            {
            foxservice.FindFoxByName(name).Food = food;
            foxservice.FindFoxByName(name).Drink = drink;
            return RedirectToAction("Index", new { name = name });
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        [Route("foxDatabase")]
        public IActionResult FoxDatabase()
        {
            return View(foxservice.ListOfFoxes);
        }

        [HttpGet("trickCenter")]
        public IActionResult TrickCenter(string name)
        {
            if (foxservice.IsLogged(name))
            {
                ViewBag.Tricks = foxservice.ListOfTricks;
                ViewBag.NumberOfTricks = foxservice.ListOfTricks.Count();
                return View(foxservice.FindFoxByName(name));
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        [HttpPost("trickCenter")]
        public IActionResult TrickCenter(string trick, string name)
        {
            if (foxservice.IsLogged(name))
            {
                foxservice.FindFoxByName(name).ListOfTricks.Add(trick);
                return RedirectToAction("trickCenter", new { name = name });
            }
            else
            {
                return RedirectToAction("login");
            }
        }
    }
}