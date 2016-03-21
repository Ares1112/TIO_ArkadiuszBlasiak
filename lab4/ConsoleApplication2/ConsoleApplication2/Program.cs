using ConsoleApplication2.ServiceReference1;
using System.Collections.Generic;
using System;

namespace ConsoleApplication2
{
    class Program
    {
        static List<Starship> starships = new List<Starship>();
        static bool _anySystem = true;
        static int _gold = 1000;
        static int _imperiumMoneyAskCount = 4;

        static void Main(string[] args)
        {
            Service1Client cosmos = new Service1Client();
            ServiceReference2.Service1Client firstOrder = new ServiceReference2.Service1Client();
            cosmos.InitializeGame();
            while(true) { 
                showMenu();
                string choice = Console.ReadLine();
                if (choice == "a")
                {
                    if (_imperiumMoneyAskCount > 0)
                    {
                        int goldFromEmpire = firstOrder.GetMoneyFromImperium();
                        _gold += goldFromEmpire;
                        _imperiumMoneyAskCount--;
                        Console.WriteLine("Dostales {0} hajsu", goldFromEmpire);
                    }
                    else
                    {
                        Console.WriteLine("Nie masz prosb");
                    }
                }
                else if (choice == "b")
                {
                    Console.WriteLine("Aktualne zloto:{0}. Wpisz za ile zlota chcesz kupic statek", _gold);
                    int money = 0;
                    if(Int32.TryParse(Console.ReadLine(), out money))
                    {
                        if (money <= _gold)
                        {
                            starships.Add(cosmos.GetStarship(money));
                            _gold -= money;
                        }
                        else
                        {
                            Console.WriteLine("Nie masz tyle hajsu");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zla kwota");
                    }
                }
                else if(choice=="c")
                {
                    SSystem toSend = cosmos.GetSystem();
                    if(toSend == null)
                    {
                        _anySystem = false;
                        Console.WriteLine("Brak systemow");
                    }
                    else
                    {
                        Console.WriteLine("System {0}. Odleglosc: {1}", toSend.Name, toSend.BaseDistance);
                        Console.WriteLine("Statkow gotowych do podrozy: {0}", starships.Count);
                        if(starships.Count == 0)
                        {
                            Console.WriteLine("Brak statkow");
                        }
                        else
                        {
                            Console.WriteLine("Wybierz statek wpisujac jego numer albo wyjdz uzywajac e");
                            for (int i = 1; i <= starships.Count; i++)
                            {
                                Starship ship = starships[i - 1];
                                Console.Write("{0} {1}", i, ship.ShipPower);
                                foreach (Person p in ship.crew)
                                {
                                    Console.Write(" {0} {1} {2} ", p.Name, p.Nick, p.Age);
                                }
                                Console.WriteLine();
                            }
                            string option = Console.ReadLine();
                            if(option == "e")
                            {
                                continue;
                            }
                            else
                            {
                                int shipNumber = 0;
                                if (Int32.TryParse(option, out shipNumber))
                                {
                                    if(shipNumber <= starships.Count && shipNumber != 0) {
                                        Starship starship = starships[shipNumber - 1];
                                        starships.RemoveAt(shipNumber-1);
                                        Starship starshipAfterSend = cosmos.sendStarship(starship, toSend.Name);
                                        if(starshipAfterSend.Gold > 0)
                                        {
                                            _gold += starshipAfterSend.Gold;
                                            starshipAfterSend.Gold = 0;
                                        }
                                        if(starshipAfterSend.crew.Length > 0)
                                        {
                                            starships.Add(starshipAfterSend);
                                        }
                                        foreach (Person p in starshipAfterSend.crew)
                                        {
                                            Console.WriteLine(p.Age);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if(choice == "d")
                {
                    Console.WriteLine(!_anySystem?"Wygrana":"Przegrana");
                    break;
                }
            }
            Console.ReadLine();
        }

        private static void showMenu()
        {
            Console.WriteLine("Masz {0} golda i {1} prosb", _gold, _imperiumMoneyAskCount);
            Console.WriteLine("a) Popros imperium o zloto");
            Console.WriteLine("b) Kup statek za zloto");
            Console.WriteLine("c) Wyslij statek do systemu");
            Console.WriteLine("d) Zakoncz gre");
        }
    }
}
