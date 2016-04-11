using LiteDB;
using ObjectManager.LiteDBBook.Model;
using ObjectManager.Model;
using System.Collections.Generic;
using System.Linq;

namespace ObjectsManager.LiteDBBook
{
    public class BookRepository
    {
        private readonly string _bookConnection = DatabaseConnections.BookConnection;

        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<BookDB>("books");
                var results = repository.FindAll();
                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Book book)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var dbObject = InverseMap(book);
                var repository = db.GetCollection<BookDB>("books");
                repository.Insert(dbObject);
                return dbObject.Id;

            }
        }

        public Book Get(int id)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<BookDB>("books");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Book Update(Book book)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var dbObject = InverseMap(book);
                var repository = db.GetCollection<BookDB>("books");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<BookDB>("books");
                return repository.Delete(id);
            }
        }

        private Book Map(BookDB bookDB)
        {
            if (bookDB == null) return null;
            return new Book()
            {
                Id = bookDB.Id,
                BookTitle = bookDB.BookTitle,
                ISBN = bookDB.ISBN
            };
        }

        private BookDB InverseMap(Book book)
        {
            if (book == null) return null;
            return new BookDB()
            {
                Id = book.Id,
                BookTitle = book.BookTitle,
                ISBN = book.ISBN
            };
        }
    }
}
