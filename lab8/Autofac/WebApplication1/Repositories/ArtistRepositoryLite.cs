using LiteDB;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ArtistRepositoryLite : IArtistsRepository
    {
        private readonly string _museumConnection = @"C:\tmp\museum";

        public List<Artist> GetAll()
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                var results = repository.FindAll();
                return results.ToList();
            }
        }

        public int Add(Artist artist)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                repository.Insert(artist);
                return artist.Id;

            }
        }

        public Artist Get(int id)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Artist Update(Artist artist)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                if (repository.Update(artist))
                    return artist;
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                return repository.Delete(id);
            }
        }
    }
}
