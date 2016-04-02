using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Models;
using ObjectsManager.LiteDBReviewAndPerson;

namespace CRUDReviewAndPersonService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {

        private readonly ReviewRepository _reviewRepository;
        private readonly PersonRepository _personRepository;

        public Service1()
        {
            this._reviewRepository = new ReviewRepository();
            this._personRepository = new PersonRepository();
        }

        public int AddPerson(Person person)
        {
            return _personRepository.Add(person);
        }

        public int AddReview(Review review)
        {
            return _reviewRepository.Add(review);
        }

        public bool DeletePerson(int id)
        {
            return _personRepository.Delete(id);
        }

        public bool DeleteReview(int id)
        {
            return _reviewRepository.Delete(id);
        }

        public List<Review> getAllReviews()
        {
            return _reviewRepository.GetAll();
        }

        public Person GetPerson(int id)
        {
            return _personRepository.Get(id);
        }

        public Review GetReview(int id)
        {
            return _reviewRepository.Get(id);
        }

        public Person UpdatePerson(Person person)
        {
            return _personRepository.Update(person);
        }

        public Review UpdateReview(Review review)
        {
            return _reviewRepository.Update(review);
        }

        public List<Person> GetAllPerson()
        {
            return _personRepository.GetAll();
        }
    }
}
