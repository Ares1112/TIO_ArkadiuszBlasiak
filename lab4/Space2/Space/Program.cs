using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Space
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:9009/BlackHole");
            ServiceHost sv = new ServiceHost(typeof(BlackHole), address);

            try
            {
                sv.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "BlackHole Service Endpoint");
                ServiceMetadataBehavior smd = new ServiceMetadataBehavior();
                smd.HttpGetEnabled = true;
                sv.Description.Behaviors.Add(smd);
                sv.Open();
                Console.WriteLine("Running");
                Console.ReadLine();
                sv.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                sv.Abort();
            }
        }
    }

    public class Person
    {
        public string Name;
        public int Age;
    }

    public class Starship
    {
        public string Name;
        public Person Capitain;
        public List<Person> Crew;
    }

    class Planet
    {
        string Name;
        int Mass;
    }

    [ServiceContract]
    interface IBlackHole
    {
        [OperationContract]
        Starship PullStarship(Starship ship);
        [OperationContract]
        string UltimateAnswer();
    }

    class BlackHole : IBlackHole
    {
        public Starship PullStarship(Starship ship)
        {
            int capitainAge = ship.Capitain.Age;
            
            return (!(capitainAge > 40) ? ShipWith20YearsOlderCrew(ship) : ship);
        }

        private Starship ShipWith20YearsOlderCrew(Starship ship)
        {
            foreach(Person person in ship.Crew)
            {
                person.Age += 20;
            }

            ship.Capitain.Age += 20;
            
            return ship;
        }

        public string UltimateAnswer()
        {
            return 42.ToString();
        }
    }
}
