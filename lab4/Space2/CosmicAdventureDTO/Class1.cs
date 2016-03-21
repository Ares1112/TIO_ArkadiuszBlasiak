using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CosmicAdventureDTO
{
    [DataContract]
    public class SSystem
    {
        public SSystem (string name, int power, int distance, int gold)
        {
            Name = name;
            MinShipPower = power;
            BaseDistance = distance;
            Gold = gold;
        }
        [DataMember]
        public string Name;
        private int _minShipPower;
        public int MinShipPower { get { return _minShipPower; } set { _minShipPower = value; } }
        [DataMember]
        public int BaseDistance;
        private int _gold;
        public int Gold { get { return _gold; } set { _gold = value; } }
    }

    [DataContract]
    public class Starship
    {
        [DataMember]
        public List<Person> crew;
        [DataMember]
        public int Gold;
        [DataMember]
        public int ShipPower;
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Nick;
        [DataMember]
        public float Age;
    }
}
