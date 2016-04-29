using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Contexts;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly IArtistsRepository _ar;
        private readonly ILogger _logger;

        public ArtistsController(IArtistsRepository ar, ILogger logger)
        {
            _ar = ar;
            _logger = logger;
        }

        public IEnumerable<Artist> GetArtists()
        {
            _logger.Write("Get all artists was called", LogLevel.INFO);
            return _ar.GetAll();
        }

        public IHttpActionResult GetArtist(int id)
        {
            _logger.Write("Get artist was called", LogLevel.INFO);
            Artist artist = _ar.Get(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [ResponseType(typeof(Artist))]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {
            _logger.Write("Put artist was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.Id)
            {
                return BadRequest();
            }

            Artist a = _ar.Update(artist);
            if (a == null)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Artist))]
        public IHttpActionResult PostArtist(Artist artist)
        {
            _logger.Write("Post artist was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ar.Add(artist);

            return CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        public IHttpActionResult DeleteArtist(int id)
        {
            _logger.Write("Delete artist was called", LogLevel.INFO);
            if (!_ar.Delete(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

