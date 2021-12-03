using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
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
                    LoginReturn lr = new LoginReturn();
                    lr.token = JwtToken.GenerateJwtToken();
                    lr.userId = temp[i].id;
                    return Ok(lr);
                }
            }

            return BadRequest();
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

            return Ok(temp);
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
            return Ok(user);
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
        public async Task<ActionResult<User>> ResetPassword(User user)
        {
            var temp = await _service.GetAll();
        
            for (int i = 0; i < temp.Count; i++)
            {
                if (user.username == temp[i].username && user.email == temp[i].email)
                {
                    temp[i].password = "defaultPassword";
                   
                    await _service.Update(temp[i].id, temp[i]);

                    MailMessage message = new MailMessage("aleksandar498@gmail.com", "pasajlics97@gmail.com");

                    string mailbody = "Your password is set to 'defaultPassword'";
                    message.Subject = "Reset password";
                    message.Body = mailbody;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                    System.Net.NetworkCredential basicCredential1 = new
                        //unjeti ispravne podatke
                    System.Net.NetworkCredential("email", "lozinka");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential1;
                    try
                    {
                        client.Send(message);
                        return Ok();
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return BadRequest();
        }


    }
}