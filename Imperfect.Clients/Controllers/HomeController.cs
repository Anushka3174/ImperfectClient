using Imperfect.Clients.Data;
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
        [HttpGet(Name = "GetOnePersonFeed")]
        public IActionResult GetOnePersonFeed()
        {
            return View();
        }

        //get feed 
        [HttpGet(Name = "GetFeed")]
        public IActionResult GetFeed()
        {
            return View();
        }

        //post picture/text
        [HttpPost(Name = "PostContent")]
        public IActionResult PostContent()
        {
            return View();
        }
        //get picture/text ???
        [HttpPost(Name = "GetOneContent")]
        public IActionResult GetOneContent()
        {
            return View();
        }

        //delete friend 
        [HttpDelete(Name = "DeleteFriend")]
        public IActionResult DeleteFriend()
        {
            return View();
        }

        //delete content 
        [HttpDelete(Name = "DeleteContent")]
        public IActionResult DeleteContent()
        {
            return View();
        }

        //like/comment friends posts
    }
}