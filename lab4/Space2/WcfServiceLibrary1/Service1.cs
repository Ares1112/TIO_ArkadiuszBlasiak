using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using CosmicAdventureDTO;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private List<SSystem> _systems;

        public Starship GetStarship(int money)
        {
            Starship new_starship = new Starship();
            List<Person> crew = new List<Person>();
            for(int i = 0; i<4; i++)
            {
                crew.Add(new Person() {Name = "Person"+i, Age = 20, Nick="p"+i });
            }
            new_starship.crew = crew;
            new_starship.Gold = 0;
            Random rnd = new Random(DateTime.Now.Millisecond);
            if (money>1000 && money <= 3000)
            {
                new_starship.ShipPower = rnd.Next(10, 25);
            }
            else if(money > 3001 && money <=10000)
            {
                new_starship.ShipPower = rnd.Next(20, 35);
            }
            else if (money>10000)
            {
                new_starship.ShipPower = rnd.Next(35, 60);
            }
            return new_starship;
        }

        public SSystem GetSystem()
        {
            return _systems.FirstOrDefault();
        }

        public void InitializeGame()
        {
            createSystems();
        }

        public Starship sendStarship(Starship starship, string systemName)
        {
            if (_systems.Exists(x => x.Name == systemName)) {
                SSystem sys = _systems.Find(x => x.Name == systemName);
                if (starship.ShipPower <= 20)
                {
                    increaseAgeAndKill(starship.crew, 12, sys.BaseDistance);   
                }
                else if (starship.ShipPower > 20 && starship.ShipPower <= 30)
                {
                    increaseAgeAndKill(starship.crew, 6, sys.BaseDistance);
                }
                else if (starship.ShipPower > 30)
                {
                    increaseAgeAndKill(starship.crew, 4, sys.BaseDistance);
                }

                if(starship.ShipPower >= sys.MinShipPower)
                {
                    starship.Gold = sys.Gold;
                    _systems.Remove(sys);
                }
            }
            else
            {
                starship.crew.Clear();
            }
            return starship;
        }

        private void increaseAgeAndKill(List<Person> crew, int scale, int baseDistance)
        {
            foreach (Person p in crew)
            {
                p.Age = p.Age + (2 * baseDistance) / scale;
            }

            crew.RemoveAll(x => x.Age > 90);
        }

        private void createSystems()
        {
            _systems = new List<SSystem>();
            for(int i = 0; i < 4; i++)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                SSystem sys = new SSystem("System" + i, rnd.Next(10, 40), 
                    rnd.Next(20, 120), rnd.Next(3000, 7000));
                _systems.Add(sys);
            }
        }
    }
}
