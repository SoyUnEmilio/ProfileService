using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public Profile[] Get()
        {
            List<Profile> profiles = new List<Profile>();
            profiles.Add(new Profile
            {
                Id = 1,
                Name = "Edwin van Wijk",
                Username = "edwinw@infosupport.com",
                GravatarUrl = "https://nl.gravatar.com/edwinvanwijk"
            });

            profiles.Add(new Profile
            {
                Id = 2,
                Name = "John Doe",
                Username = "john@doe.com",
                GravatarUrl = null
            });

            profiles.Add(new Profile
            {
                Id = 3,
                Name = "Jane Doe",
                Username = "jane@doe.com",
                GravatarUrl = null
            });

            return profiles.ToArray();
        }

        // GET api/profiles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Profile profile = Get()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (profile == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(profile);
        }
    }
}
