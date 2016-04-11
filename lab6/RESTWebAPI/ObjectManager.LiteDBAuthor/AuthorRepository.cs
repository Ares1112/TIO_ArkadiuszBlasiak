using LiteDB;
using ObjectManager.LiteDBAuthor.Model;
using ObjectManager.Model;
using System.Collections.Generic;
using System.Linq;

namespace ObjectsManager.LiteDBAuthor
{
    public class AuthorRepository
    {
        private readonly string _authorConnection = DatabaseConnections.AuthorConnection;

        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("author");
                var results = repository.FindAll();
                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Author author)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var dbObject = InverseMap(author);
                var repository = db.GetCollection<AuthorDB>("author");
                repository.Insert(dbObject);
                return dbObject.Id;

            }
        }

        public Author Get(int id)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("author");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Author Update(Author author)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var dbObject = InverseMap(author);
                var repository = db.GetCollection<AuthorDB>("author");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("author");
                return repository.Delete(id);
            }
        }

        private Author Map(AuthorDB authorDB)
        {
            if (authorDB == null) return null;
            return new Author()
            {
                Id = authorDB.Id,
                AuthorName = authorDB.AuthorName,
                AuthorSurname = authorDB.AuthorSurname
            };
        }

        private AuthorDB InverseMap(Author author)
        {
            if (author == null) return null;
            return new AuthorDB()
            {
                Id = author.Id,
                AuthorName = author.AuthorName,
                AuthorSurname = author.AuthorSurname
            };
        }
    }
}
