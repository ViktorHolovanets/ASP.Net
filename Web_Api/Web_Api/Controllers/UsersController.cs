using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {
            if (Singleton.getInstance().Users.Count() < 1)
            {
                Singleton.getInstance().Users.Add(new Models.User()
                {
                    Name = "Bob",
                    Age = 15
                });
                Singleton.getInstance().Users.Add(new Models.User()
                {
                    Name = "Josh",
                    Age = 35
                });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Singleton.getInstance().Users;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            User user = Singleton.getInstance().Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            Singleton.getInstance().Users.Add(user);
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public ActionResult<User> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!Singleton.getInstance().Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }
            User temp_user = Singleton.getInstance().Users.FirstOrDefault(x => x.Id == user.Id);
            temp_user.Age = user.Age;
            temp_user.Name = user.Name;
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(string id)
        {
            User user = Singleton.getInstance().Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            Singleton.getInstance().Users.Remove(user);
            return Ok(user);
        }
    }
}
