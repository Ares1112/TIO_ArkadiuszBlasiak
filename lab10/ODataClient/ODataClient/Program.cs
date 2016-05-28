using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:49847/";
            var container = new ODataClientas.Default.Container(new Uri(serviceUri));

            Console.WriteLine("Lista wszystkich gier:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0}", game.Title);
            }

            Console.WriteLine("Dodanie nowej gry");
            container.AddToGames(new ODataClientas.Library.Game() { Title = "Game11", CreatorCompany = "Company11", Year = 2012, AgeRate = 33 });
            var serviceResponse = container.SaveChanges();

            Console.WriteLine("Lista wszystkich gier:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0}", game.Title);
            }

            Console.WriteLine("Lista wszystkich koszulek na karty:");
            foreach (var card in container.GetAvailableCardShirts().ToList())
            {
                Console.WriteLine("{0}", card.Name);
            }

            Console.WriteLine("Lista wszystkich sklepow:");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0}", store.Name);
            }


            Console.WriteLine("Usuniecie sklepow Name1");
            container.Stores.Where(x => x.Name == "Name1").ToList().ForEach(x => container.DeleteObject(x));
            container.SaveChanges();

            Console.WriteLine("Lista wszystkich sklepow:");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0}", store.Name);
            }

            Console.ReadKey();
        }
    }
}