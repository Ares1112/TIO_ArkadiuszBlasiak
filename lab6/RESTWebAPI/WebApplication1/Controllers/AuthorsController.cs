using ObjectManager.Model;
using ObjectsManager.LiteDBAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class AuthorsController : ApiController
    {
        private readonly AuthorRepository ar;

        public AuthorsController()
        {
            ar = new AuthorRepository();
        }

        // GET api/authors
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ar.GetAll());
        }

        // GET api/authors/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ar.Get(id));
        }

        // POST api/authors
        public HttpResponseMessage Post([FromBody]Author author)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ar.Add(author));
        }

        // PUT api/authors/5
        public HttpResponseMessage Put(int id, [FromBody]Author author)
        {
            author.Id = id;
            ar.Update(author);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/authors/5
        public HttpResponseMessage Delete(int id)
        {
            ar.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
