using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NFluent;
using System.Linq;

namespace PersonModel.Tests
{
    [TestClass]
    public class PersonModelTest
    {
        private List<Person> persons;

        [TestInitialize]
        public void Initialize()
        {
            persons = GetPersons();
            CleanPersonsAndAnimals();
            AddNewPersonsWithAnimals();
        }

        [TestMethod]
        public void Should_return_the_collection_saved()
        {
            using (var dbContext = new PersonModelContext())
            {
                var persons = dbContext.Persons.ToListAsync().Result;
                Check.That(persons.Count()).IsEqualTo(persons.Count);
            }
        }

        [TestMethod]
        public void Should_Throw_an_object_disposed_exception_when_get_enumerable_elements_after_disposing_dbcontext()
        {
            IEnumerable<Person> queriedPersons = null;
            using (var dbContext = new PersonModelContext())
            {
                queriedPersons = GetPersons(dbContext);
            }

            Check.ThatCode(() => queriedPersons.Count())
                .Throws<ObjectDisposedException>();
        }

        private static IEnumerable<Person> GetPersons(PersonModelContext dbContext)
        {
            var persons = dbContext.Persons.Where(person => person.Id % 2 == 0);
            return persons.Skip(1);
        }

        private void CleanPersonsAndAnimals()
        {
            using (var dbContext = new PersonModelContext())
            {
                var deleteAnimals = $"delete from Animal";
                dbContext.Database.ExecuteSqlRaw(deleteAnimals);
                var deletePersons = $"delete from Persons";
                dbContext.Database.ExecuteSqlRaw(deletePersons);
            }
        }

        private void AddNewPersonsWithAnimals()
        {
            using (var dbContext = new PersonModelContext())
            {
                dbContext.Persons.AddRange(persons);
                dbContext.SaveChanges();
            }
        }

        private static List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();
            for (int i = 1; i < 10; i++)
            {
                int idFirstAnimal = i * 10;
                List<Animal> animals = new List<Animal>
                    {
                        new Animal
                        {
                            Id = idFirstAnimal,
                            Name = "Rocky"
                        },
                        new Animal
                        {
                            Id = idFirstAnimal + 1,
                            Name = "Catty"
                        }
                    };
                Person person = new Person
                {
                    Id = i,
                    Name = "Jack",
                    Animals = animals
                };
                persons.Add(person);
            }

            return persons;
        }
    }
}
