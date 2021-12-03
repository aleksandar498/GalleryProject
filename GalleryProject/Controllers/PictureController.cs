using System;
using System.Collections.Generic;
using System.IO;
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
    public class PictureController : ControllerBase
    {
        private readonly GalleryContext _context;

        PictureService _service;

        public PictureController(GalleryContext context)
        {
            _context = context;
            _service = new PictureService(_context);
        }
        // GET: api/Picture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Picture>>> GetPicture()
        {
            var temp = await _service.GetAll();
            return Ok(temp);
        }

        // GET: api/Picture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Picture>> GetPicture(int id)
        {
            var temp = await _service.GetById(id);
            if (temp == null) return new NotFoundObjectResult(null);

            return Ok(temp);
        }

        // PUT: api/Picture/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Picture>> PutPicture([FromRoute]int id, Picture user)
        {
            await _service.Update(id,user);
            return Ok();
        }

        // POST: api/Picture
        [HttpPost]
        public async Task<ActionResult<Picture>> PostPicture(Picture user)
        {
           
            await _service.Add(user);
            return Ok(user);
        }

        // DELETE: api/Picture/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Picture>> DeletePicture(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}