using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Initializers
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            List<Book> defaultBooks = new List<Book>();
            defaultBooks.Add(new Book() { BookTitle = "BOOK1", ISBN = "123" });
            defaultBooks.Add(new Book() { BookTitle = "BOOK2", ISBN = "1234" });
            defaultBooks.Add(new Book() { BookTitle = "BOOK3", ISBN = "12345" });
            foreach (Book b in defaultBooks)
                context.Books.Add(b);
            context.SaveChanges();

            List<Author> defaultAuthors = new List<Author>();
            defaultAuthors.Add(new Author { AuthorName = "NAME1", AuthorSurname = "SURNAME1" });
            defaultAuthors.Add(new Author { AuthorName = "NAME2", AuthorSurname = "SURNAME2" });
            defaultAuthors.Add(new Author { AuthorName = "NAME3", AuthorSurname = "SURNAME3" });
            foreach (Author a in defaultAuthors)
                context.Authors.Add(a);
            context.SaveChanges();

        }
    }
}