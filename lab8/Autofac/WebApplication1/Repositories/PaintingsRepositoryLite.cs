using LiteDB;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class PaintingsRepositoryLite
    {
        private readonly string _museumConnection = @"C:\tmp\museum";

        public List<Painting> GetAll()
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Painting>("painting");
                var results = repository.FindAll();
                return results.ToList();
            }
        }

        public int Add(Painting painting)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Painting>("painting");
                repository.Insert(painting);
                return painting.Id;

            }
        }

        public Painting Get(int id)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Painting>("painting");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Painting Update(Painting painting)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Painting>("painting");
                if (repository.Update(painting))
                    return painting;
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Painting>("painting");
                return repository.Delete(id);
            }
        }
    }
}
