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
    public class AlbumController : ControllerBase
    {
        private readonly GalleryContext _context;

        AlbumService _service;

        public AlbumController(GalleryContext context)
        {
            _context = context;
            _service = new AlbumService(_context);
        }
        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbum()
        {
            var temp = await _service.GetAll();
            return Ok(temp);
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var temp = await _service.GetById(id);
            if (temp == null) return new NotFoundObjectResult(null);

            return (temp);
        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Album>> PutAlbum([FromRoute]int id, Album user)
        {
            await _service.Update(id,user);
            return Ok();
        }

        // POST: api/Album
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album user)
        {
            await _service.Add(user);
            return (user);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> DeleteAlbum(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}