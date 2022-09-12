﻿using Imperfect.Clients.Data;
using Imperfect.Clients.Models;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Imperfect.Clients.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(ProfileContext.Profiles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //post/get friendship request 

        //get person from search

        //get persons feed 

        //get feed 

        //post picture/text

        //delete friend 

        //like/comment friends posts
    }
}