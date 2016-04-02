using LiteDB;
using ObjectsManager.LiteDBMovie.Models;
using ObjectsManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ObjectsManager.LiteDBMovie
{
    public class MoviesRepository
    {
        private readonly string _moviesConnection = DatabaseConnections.MovieConnection;

        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<MoviesDB>("movies");
                var results = repository.FindAll();
                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Movie movie)
        {
            using(var db = new LiteDatabase(this._moviesConnection))
            {
                var dbObject = InverseMap(movie);
                var repository = db.GetCollection<MoviesDB>("movies");
                repository.Insert(dbObject);
                return dbObject.Id;

            }
        }

        public Movie Get(int id)
        {
            using(var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<MoviesDB>("movies");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Movie Update(Movie movie)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var dbObject = InverseMap(movie);
                var repository = db.GetCollection<MoviesDB>("movies");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<MoviesDB>("movies");
                return repository.Delete(id);
            }
        }

        private Movie Map(MoviesDB moviesDB)
        {
            if (moviesDB == null) return null;
            return new Movie()
            {
                Id = moviesDB.Id,
                Title = moviesDB.Title,
                ReleaseYear = moviesDB.ReleaseYear
            };
        }

        private MoviesDB InverseMap(Movie movie)
        {
            if (movie == null) return null;
            return new MoviesDB()
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear
            };
        }
    }
}
