using ObjectsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRUDMovieService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int AddMovie(Movie movie);

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        List<Movie> getAllMovies();

        [OperationContract]
        Movie UpdateMovie(Movie movie);

        [OperationContract]
        bool DeleteMovie(int id);
    }
}
