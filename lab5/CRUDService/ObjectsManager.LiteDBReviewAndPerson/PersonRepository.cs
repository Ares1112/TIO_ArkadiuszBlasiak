using LiteDB;
using ObjectsManager.LiteDBReviewAndPerson.Models;
using ObjectsManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ObjectsManager.LiteDBReviewAndPerson
{
    public class PersonRepository
    {
        private readonly string _personConnection = DatabaseConnections.ReviewAndPersonConnection;

        public List<Person> GetAll()
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<PersonDB>("person");
                var results = repository.FindAll();
                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Person person)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var dbObject = InverseMap(person);
                var repository = db.GetCollection<PersonDB>("person");
                repository.Insert(dbObject);
                return dbObject.Id;

            }
        }

        public Person Get(int id)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<PersonDB>("person");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Person Update(Person person)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var dbObject = InverseMap(person);
                var repository = db.GetCollection<PersonDB>("person");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<PersonDB>("person");
                return repository.Delete(id);
            }
        }

        private Person Map(PersonDB personDB)
        {
            if (personDB == null) return null;
            return new Person()
            {
                Id = personDB.Id,
                Name = personDB.Name,
                Surname = personDB.Surname
                
            };
        }

        private PersonDB InverseMap(Person person)
        {
            if (person == null) return null;
            return new PersonDB()
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname
            };
        }
    }
}
