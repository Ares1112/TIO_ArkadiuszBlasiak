using LiteDB;
using ObjectsManager.LiteDBReviewAndPerson.Models;
using ObjectsManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ObjectsManager.LiteDBReviewAndPerson
{
    public class ReviewRepository
    {
        private readonly string _reviewConnection = DatabaseConnections.ReviewAndPersonConnection;

        public List<Review> GetAll()
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("review");
                var results = repository.FindAll();
                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Review review)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var dbObject = InverseMap(review);
                var repository = db.GetCollection<ReviewDB>("review");
                repository.Insert(dbObject);
                return dbObject.Id;

            }
        }

        public Review Get(int id)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("review");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Review Update(Review review)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var dbObject = InverseMap(review);
                var repository = db.GetCollection<ReviewDB>("review");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("review");
                return repository.Delete(id);
            }
        }

        private Review Map(ReviewDB reviewDB)
        {
            if (reviewDB == null) return null;
            var personRepo = new PersonRepository();
            Person person = personRepo.Get(reviewDB.AuthorId);
            return new Review()
            {
                Id = reviewDB.Id,
                Content = reviewDB.Content,
                Score = reviewDB.Score,
                Author = person,
                MovieId = reviewDB.MovieId
                
            };
        }

        private ReviewDB InverseMap(Review review)
        {
            if (review == null) return null;
            return new ReviewDB()
            {
                Id = review.Id,
                Content = review.Content,
                Score = review.Score,
                AuthorId = review.Author.Id,
                MovieId = review.MovieId
            };
        }
    }
}
