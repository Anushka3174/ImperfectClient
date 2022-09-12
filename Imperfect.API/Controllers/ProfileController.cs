using Imperfect.API.Data;
using Imperfect.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imperfect.API.Controllers
{
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
    }
}
