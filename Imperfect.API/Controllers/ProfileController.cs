using Imperfect.API.Data;
using Imperfect.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imperfect.API.Controllers
{
    private String _id = "";

    [ApiController]
    [Route("[controller]")]
    public class ProfileController
    {
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsersProfile")]
        public IEnumerable<Profile> Get()
        {
           return ProfileContext.Profiles;
        }
        //post/get friendship request 

        //get person from search

        //get persons feed 
        [HttpGet(Name = "GetOnePersonFeed")]
        public IActionResult GetOnePersonFeed(String id)
        {
            //sjekke om det er deg selv
            //hente ut spesifikk bruker 
            //sende med informasjon 
                    // bilder/content 
                    // annen informasjon
            //hent fra database 
            Profile p = getFromDatabase();
            if(_id != p.getId()){
                //hent fra database
            }
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
