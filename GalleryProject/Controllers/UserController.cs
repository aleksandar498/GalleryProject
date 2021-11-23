using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryProject.Data;
using GalleryProject.Models;
using GalleryProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GalleryProject.Controllers
{
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
        public async Task<ActionResult<User>> PutUser(User user)
        {
            await _service.Update(user);
            return Ok();
        }

        // POST: api/User
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


    }
}