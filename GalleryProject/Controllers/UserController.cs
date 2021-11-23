using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryProject.Data;
using GalleryProject.Models;
using GalleryProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GalleryProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GalleryContext _context;   

        UserService _service;

        public UserController(GalleryContext context)
        {           
            _context = context;
            _service = new UserService(_context);
        }
        [AllowAnonymous]
        // POST: api/User/login
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(User user)
        {
            var temp = await _service.GetAll();
            for(int i = 0; i < temp.Count; i++)
            {
                if(user.username==temp[i].username && user.password == temp[i].password)
                {
                    return new ObjectResult(JwtToken.GenerateJwtToken());
                }
            }
           
            return (user);
        }
        // GET: api/User
        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            var temp = await _service.GetAll();
            return Ok(temp);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var temp = await _service.GetById(id);
            if (temp == null) return new NotFoundObjectResult(null);

            return (temp);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser([FromRoute]int id,User user)
        {
            await _service.Update(id,user);
            return Ok();
        }

        // POST: api/User
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
           await _service.Add(user);             
           return (user);
        }
        
        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
        // POST: api/User/reset
        [HttpPost("reset")]
        public async Task<ActionResult<User>> ResetPassword( string email,string username)
        {
            var temp = await _service.GetAll();
            int index=0;
            for (int i = 0; i < temp.Count; i++)
            {
                if (username == temp[i].username && email == temp[i].email)
                {
                    temp[i].password = "defaultPassword";
                    index = i;
                }
            }

            return (temp[index]);
        }


    }
}