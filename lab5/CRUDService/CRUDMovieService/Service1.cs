using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Models;
using ObjectsManager.LiteDBMovie;

namespace CRUDMovieService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {

        private readonly MoviesRepository _movieRepository;

        public Service1()
        {
            this._movieRepository = new MoviesRepository();
        }

        public int AddMovie(Movie movie)
        {
            return this._movieRepository.Add(movie);
        }

        public bool DeleteMovie(int id)
        {
            return this._movieRepository.Delete(id);
        }

        public List<Movie> getAllMovies()
        {
            return this._movieRepository.GetAll();
        }

        public Movie GetMovie(int id)
        {
            return this._movieRepository.Get(id);
        }

        public Movie UpdateMovie(Movie movie)
        {
            return this._movieRepository.Update(movie);
        }
    }
}
