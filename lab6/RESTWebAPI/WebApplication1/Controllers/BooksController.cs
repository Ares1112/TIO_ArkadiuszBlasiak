using ObjectManager.Model;
using ObjectsManager.LiteDBBook;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class BooksController : ApiController
    {
        private readonly BookRepository br;

        public BooksController()
        {
             br = new BookRepository();
        }

        // GET api/books
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, br.GetAll());
        }

        // GET api/books/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, br.Get(id));
        }

        // GET api/books/?search=qwerty
        public HttpResponseMessage Get([FromUri] string search)
        {
            return Request.CreateResponse(HttpStatusCode.OK, br.GetAll().Where(x => x.BookTitle.Contains(search)));
        }

        // POST api/books
        public HttpResponseMessage Post([FromBody]Book book)
        {
            return Request.CreateResponse(HttpStatusCode.OK, br.Add(book));
        }

        // PUT api/books/5
        public HttpResponseMessage Put(int id, [FromBody]Book book)
        {
            book.Id = id;
            br.Update(book);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/books/5
        public HttpResponseMessage Delete(int id)
        {
            br.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
