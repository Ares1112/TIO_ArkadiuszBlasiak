using EasyNetQ;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Podaj nick");
                string nick = Console.ReadLine();
                Random rnd = new Random();
                int id = rnd.Next(1000000000);
                bus.Subscribe<Message>(id.ToString(), HandleTextMessage);
                var input = "";
                Console.WriteLine("Wpisz wiadomosc");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new Message
                    {
                        Name = nick,
                        Text = input
                    });
                }
            }
        }
        static void HandleTextMessage(Message textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}: {1}", textMessage.Name, textMessage.Text);
            Console.ResetColor();
        }
    }
}
