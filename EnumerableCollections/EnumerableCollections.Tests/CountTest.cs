using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class CountTest
    {
        [TestMethod]
        public void Should_count_person_that_name_stating_with_L()
        {
            var persons = GetPersons();

            var number = persons.Count(person => person.Name.StartsWith('L'));

            Check.That(number).IsEqualTo(2);
        }

        [TestMethod]
        public void Should_return_long_int_when_count_person_that_name_stating_with_L()
        {
            var persons = GetPersons();

            var number = persons.LongCount(person => person.Name.StartsWith('L'));

            Check.That(number).IsInstanceOf<Int64>();
            Check.That(number).IsEqualTo(2);
        }

        [TestMethod]
        public void Should_sum_person_ids()
        {
            var persons = GetPersons();

            var sum = persons.Sum(person => person.Id);

            Check.That(sum).IsEqualTo(10);
        }

        [TestMethod]
        public void Should_return_min_id()
        {
            var persons = GetPersons();

            var id = persons.Min(person => person.Id);

            Check.That(id).IsEqualTo(1);
        }

        [TestMethod]
        public void Should_return_min_name()
        {
            var persons = GetPersons();

            var id = persons.Min(person => person.Name);

            Check.That(id).IsEqualTo("Anne");
        }

        [TestMethod]
        public void Should_return_max_id()
        {
            var persons = GetPersons();

            var id = persons.Max(person => person.Id);

            Check.That(id).IsEqualTo(4);
        }

        [TestMethod]
        public void Should_return_max_name()
        {
            var persons = GetPersons();

            var id = persons.Max(person => person.Name);

            Check.That(id).IsEqualTo("Lucie");
        }

        [TestMethod]
        public void Should_return_average_id()
        {
            var persons = GetPersons();

            var averageId = persons.Average(person => person.Id);

            Check.That(averageId).IsEqualTo(2.5);
        }

        [TestMethod]
        public void Should_return_aggregate_ids()
        {
            var persons = GetPersons();

            var aggregatedPerson = persons.Aggregate((person, otherPerson) => new Person(person.Id * otherPerson.Id, "Imaginary"));

            Check.That(aggregatedPerson).IsEqualTo(new Person(24, "Imaginary"));
        }

        private IEnumerable<Person> GetPersons()
        {
            yield return new Person(2, "Lucie");
            yield return new Person(4, "Laura");
            yield return new Person(1, "Arnaud");
            yield return new Person(3, "Anne");
        }
    }
}
