using ObjectsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRUDReviewAndPersonService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int AddReview(Review review);

        [OperationContract]
        Review GetReview(int id);

        [OperationContract]
        List<Review> getAllReviews();

        [OperationContract]
        Review UpdateReview(Review review);

        [OperationContract]
        bool DeleteReview(int id);

        ///////////////////////////

        [OperationContract]
        int AddPerson(Person person);

        [OperationContract]
        Person GetPerson(int id);

        [OperationContract]
        List<Person> GetAllPerson();

        [OperationContract]
        Person UpdatePerson(Person person);

        [OperationContract]
        bool DeletePerson(int id);
    }
}
