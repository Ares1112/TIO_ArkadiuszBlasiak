using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Circus Cyrk = new Circus();
            Zoo Zuu = new Zoo();
            while (true)
            {
                Console.WriteLine("a) Prezentacja zwierzat w cyrku Cyrk");
                Console.WriteLine("b) Obejrzenie programu cyrku Cyrk");
                Console.WriteLine("c) Posluchanie dzwiekow zoo Zuu");
                Console.WriteLine("d) Wyswietla imie pierwszego znalezionego futrzaka w Zoo");
                Console.WriteLine("e) Wyswietla wszystkie imiona zwierzat w Cyrku");

                string read = Console.ReadLine();

                if(read == "a")
                {
                    Console.WriteLine(Cyrk.AnimalsIntroduction());
                }
                else if(read == "b")
                {
                    Console.WriteLine(Cyrk.Show());
                }
                else if(read == "c")
                {
                    Console.WriteLine(Zuu.Sounds());
                }
                else if(read == "d")
                {
                    Animal firstAnimal = Zuu.Animals.FirstOrDefault();
                    Console.WriteLine(firstAnimal == null ? "Zwierzeta uciekly :(" : firstAnimal.Name);
                }
                else if(read == "e")
                {
                    foreach(Animal animal in Cyrk.Animals)
                    {
                        Console.WriteLine(animal.Name);
                    }
                }
                else
                {
                    continue;
                }
                break;
            }
            Console.ReadLine();
        }
    }

    class Animal
    {
        public string Name;
        public float Weight;
        public bool HaveFur;

        public virtual string Sound()
        {
            return "Sound!";
        }

        public virtual string Trick()
        {
            return "Roll!";
        }

        public virtual int CountLegs()
        {
            return 4;
        }
    }

    class Circus : ICircus
    {
        public List<Animal> Animals;
        string Name;

        public Circus()
        {
            Animals = new List<Animal>();
            Animals.Add(new Cat { Name = "Blackie" });
            Animals.Add(new Pony { Name = "Ponie" });
            Animals.Add(new Ant { Name = "Antie" });
            Animals.Add(new Elephant { Name = "Elephantie" });
            Animals.Add(new Giraffe { Name = "Giraffi" });
        }

        public string AnimalsIntroduction()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Animal animal in Animals)
            {
                sb.Append(animal.Sound());
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public int Patter(int howMuch)
        {
            int total = 0;
            foreach (Animal animal in Animals)
            {
                total += howMuch * animal.CountLegs();
            }
            return total;
        }

        public string Show()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Animal animal in Animals)
            {
                sb.Append(animal.Trick());
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }

    class Zoo : IZoo
    {
        public List<Animal> Animals;
        public string Name;

        public Zoo()
        {
            Animals = new List<Animal>();
            Animals.Add(new Cat { Name = "Blackie" });
            Animals.Add(new Pony { Name = "Ponie" });
            Animals.Add(new Ant { Name = "Antie" });
            Animals.Add(new Elephant { Name = "Elephantie" });
            Animals.Add(new Giraffe { Name = "Giraffi" });
            Animals.Add(new Cat { Name = "Blackie2" });
            Animals.Add(new Pony { Name = "Ponie2" });
            Animals.Add(new Ant { Name = "Antie2" });
            Animals.Add(new Elephant { Name = "Elephantie2" });
            Animals.Add(new Giraffe { Name = "Giraffi2" });
        }

        public string Sounds()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Animal animal in Animals)
            {
                sb.Append(animal.Sound());
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }

    class Cat : Animal
    {
        public string Color;

        public override string Sound()
        {
            return "Meow!";
        }

        public override string Trick()
        {
            return "Sit!";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }

    class Pony : Animal
    {
        public bool IsMagic;

        public override string Sound()
        {
            return "Muu!";
        }

        public override string Trick()
        {
            return "Stand!";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }

    class Ant : Animal
    {
        public bool IsQueen;

        public override string Sound()
        {
            return "Click!";
        }

        public override string Trick()
        {
            return "DoAntThings!";
        }

        public override int CountLegs()
        {
            return 6;
        }
    }

    class Elephant : Animal
    {
        public override string Sound()
        {
            return "Truu!";
        }

        public override string Trick()
        {
            return "Drink!";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }

    class Giraffe : Animal
    {
        public override string Sound()
        {
            return "Boo!";
        }

        public override string Trick()
        {
            return "Eat!";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }

    interface ICircus
    {
        string AnimalsIntroduction();
        string Show();
        int Patter(int howMuch);
    }

    interface IZoo
    {
        string Sounds();
    }
}
