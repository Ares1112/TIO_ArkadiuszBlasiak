using SpaceClient.Space;
using System;

namespace SpaceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Starship testStarship = createTestStarship();
                PresentCrew(testStarship);
                BlackHoleClient client = new BlackHoleClient();
                Starship pulled = client.PullStarship(testStarship);
                Console.WriteLine("\nWhat is the answer to life, the universe and everything? {0}", client.UltimateAnswer());
                Console.WriteLine("\nAFTER PULL\n");
                PresentCrew(pulled);
            }
            catch(System.ServiceModel.EndpointNotFoundException e)
            {
                Console.WriteLine("Server not working!");
            }
            Console.WriteLine("\nPress enter to exit");
            Console.ReadLine();
        }

        private static Starship createTestStarship()
        {
            Starship ship = new Starship();
            attachTestCrew(ship);
            attachTestCapitain(ship);
            return ship;
        }

        private static void attachTestCrew(Starship ship)
        {
            Person[] crew = new Person[] {
                new Person { Name = "Twardowsky", Age = 55 },
                new Person { Name = "Kowalsky", Age = 20 },
                new Person { Name = "Armstrong", Age = 33 },
                new Person { Name = "Diesel", Age = 66 },
                new Person { Name = "DiCaprio", Age = 31 }
            };
            ship.Crew = crew;
        }

        private static void attachTestCapitain(Starship ship)
        {
            Person capitain = new Person { Name = "Kapityn", Age = 20 };
            ship.Capitain = capitain;
        }

        static void PresentCrew(Starship ship)
        {
            foreach (Person p in ship.Crew)
            {
                WriteNameAndAge(p);
            }
            WriteNameAndAge(ship.Capitain);
        }

        static void WriteNameAndAge(Person p)
        {
            Console.WriteLine("{0} {1}", p.Name, p.Age);
        }
    }
}
