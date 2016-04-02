using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDClient
{
    class Program
    {

        static CRUDMovieServiceReference.Service1Client movieClient = new CRUDMovieServiceReference.Service1Client();
        static CRUDReviewAndPersonServiceReference.Service1Client reviewAndPersonClient = new CRUDReviewAndPersonServiceReference.Service1Client();
        static string name;
        static string surname;
        static int userId = 0;

        static void Main(string[] args)
        {
            askForNameAndSurname();
            writeNameToDB();
            checkIfAnyMovieAndAdd();
            while (true)
            {
                showMainMenu();
                parseOption(Console.ReadLine());
            }
        }

        private static void askForNameAndSurname()
        {
            Console.WriteLine("Podaj imie");
            name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko");
            surname = Console.ReadLine();
        }

        private static void writeNameToDB()
        {
            CRUDReviewAndPersonServiceReference.Person p = reviewAndPersonClient.GetAllPerson().LastOrDefault();
            userId = p == null ? 1 : p.Id+1;

            reviewAndPersonClient.AddPerson(new CRUDReviewAndPersonServiceReference.Person() { Id = userId, Name = name, Surname = surname });
        }

        private static void checkIfAnyMovieAndAdd()
        {
            if(movieClient.getAllMovies().Length == 0)
            {
                movieClient.AddMovie(new CRUDMovieServiceReference.Movie() { Id = 1, ReleaseYear = 2002, Title = "Film 1" });
                movieClient.AddMovie(new CRUDMovieServiceReference.Movie() { Id = 2, ReleaseYear = 2006, Title = "Film 2" });
                movieClient.AddMovie(new CRUDMovieServiceReference.Movie() { Id = 3, ReleaseYear = 2007, Title = "Film 3" });
            }
        }

        private static void showMainMenu()
        {
            Console.WriteLine("a) dodanie recenzji");
            Console.WriteLine("b) edycja recenzji");
            Console.WriteLine("c) usuniecie recenzji");
            Console.WriteLine("d) zobacz recenzje dla filmow");
            Console.WriteLine("e) dodaj film");
        }

        private static void parseOption(string option)
        {
            if(option == "a")
            {
                doAThings();
            }
            else if (option == "b")
            {
                doBThings();
            }
            else if (option == "c")
            {
                doCThings();
            }
            else if (option == "d")
            {
                doDThings();
            }
            else if (option == "e")
            {
                doEThings();
            }
        }

        private static void doAThings()
        {
            foreach(CRUDMovieServiceReference.Movie movie in movieClient.getAllMovies())
            {
                Console.WriteLine("{0} {1} {2}", movie.Id, movie.Title, movie.ReleaseYear);
            }
            Console.WriteLine("Wpisz numer filmu ktory chcesz ocenic");
            int option = 0;
            if(Int32.TryParse(Console.ReadLine(), out option)){
                Console.WriteLine("Wpisz recenzje, ENTER konczy");
                string content = Console.ReadLine();
                Console.WriteLine("Wpisz ocene (0-100)");
                int rate = 0;
                while(!Int32.TryParse(Console.ReadLine(), out rate))
                {
                    Console.WriteLine("Zla ocena, wpisz jeszcze raz");
                }
                if (rate < 0 || rate > 100)
                {
                    Console.WriteLine("zakres 0-100");
                    return;
                }
                CRUDReviewAndPersonServiceReference.Review r = reviewAndPersonClient.getAllReviews().LastOrDefault();
                int newId = r == null ? 1 : r.Id + 1;
                CRUDReviewAndPersonServiceReference.Person user = reviewAndPersonClient.GetPerson(userId);
                reviewAndPersonClient.AddReview(new CRUDReviewAndPersonServiceReference.Review() {
                    Id = newId, Content = content, Score = rate, Author = user, MovieId = option
                });
                return;
            }
            Console.WriteLine("Zly numer");
        }

        private static void doBThings()
        {
            foreach (CRUDReviewAndPersonServiceReference.Review review in reviewAndPersonClient.getAllReviews())
            {
                if (review.Author.Id == userId)
                    Console.WriteLine("{0} {1} {2}", review.Id, review.Content, review.Score);
            }
            Console.WriteLine("Wpisz numer recenzji ktora chcesz zmienic");
            int option = 0;
            if (Int32.TryParse(Console.ReadLine(), out option))
            {
                CRUDReviewAndPersonServiceReference.Review chosenReview = reviewAndPersonClient.GetReview(option);
                Console.WriteLine(chosenReview.Content);
                Console.WriteLine("Edytuj recenzje, ENTER konczy");
                string content = Console.ReadLine();
                Console.WriteLine("Edytuj ocene (0-100)");
                int rate = 0;
                while (!Int32.TryParse(Console.ReadLine(), out rate))
                {
                    Console.WriteLine("Zla ocena, wpisz jeszcze raz");
                }
                if (rate < 0 || rate > 100)
                {
                    Console.WriteLine("zakres 0-100");
                    return;
                }
                chosenReview.Content = content;
                chosenReview.Score = rate;
                reviewAndPersonClient.UpdateReview(chosenReview);
                return;
            }
        }

        private static void doCThings()
        {
            foreach (CRUDReviewAndPersonServiceReference.Review review in reviewAndPersonClient.getAllReviews())
            {
                if (review.Author.Id == userId)
                    Console.WriteLine("{0} {1} {2}", review.Id, review.Content, review.Score);
            }
            Console.WriteLine("Wpisz numer recenzji ktora chcesz usunac");
            int option = 0;
            if (Int32.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Czy na pewno chcesz usunac recenzje {0} T/N (N domyslnie)?", option);
                string content = Console.ReadLine();
                if(content == "T")
                {
                    reviewAndPersonClient.DeleteReview(option);
                    Console.WriteLine("Usunieto");
                }
                return;
            }
        }

        private static void doDThings()
        {
            foreach (CRUDMovieServiceReference.Movie movie in movieClient.getAllMovies())
            {
                Console.WriteLine("{0} {1} {2}", movie.Id, movie.Title, movie.ReleaseYear);
            }
            Console.WriteLine("Wpisz numer filmu ktory chcesz zobaczyc");
            int option = 0;
            CRUDMovieServiceReference.Movie chosenMovie = movieClient.GetMovie(option);
            int avg = 0;
            CRUDReviewAndPersonServiceReference.Review[] reviews = reviewAndPersonClient.getAllReviews();
            if (Int32.TryParse(Console.ReadLine(), out option))
            {
                int i = 0;
                foreach(CRUDReviewAndPersonServiceReference.Review review in reviews)
                {
                    if(review.MovieId == option)
                    {
                        Console.WriteLine("{0} ||| {1} {2}", review.Content, review.Author.Name, review.Author.Surname);
                        i++;
                        avg += review.Score;
                    }
                    
                }
                if(i > 0)
                    Console.WriteLine("Srednia ocen: {0}", avg / i);
            }
        }

        private static void doEThings()
        {
            Console.WriteLine("Podaj tytul");
            string title = Console.ReadLine();
            Console.WriteLine("Podaj rok");
            int year = 0;
            if (Int32.TryParse(Console.ReadLine(), out year))
            {
                CRUDMovieServiceReference.Movie lastMovie = movieClient.getAllMovies().LastOrDefault();
                int id = lastMovie == null ? 1 : lastMovie.Id + 1;
                movieClient.AddMovie(new CRUDMovieServiceReference.Movie() { Title = title, ReleaseYear = year, Id = id});
            }
        }
    }
}
