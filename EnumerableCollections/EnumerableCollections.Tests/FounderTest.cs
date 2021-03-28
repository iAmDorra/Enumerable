using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class FounderTest
    {
        [TestMethod]
        public void Should_return_first_element()
        {
            var persons = GetPersons();

            var first = persons.First();

            Check.That(first).IsEqualTo(new Person(2, "Lucie"));
        }

        [TestMethod]
        public void Should_return_first_element_condition()
        {
            var persons = GetPersons();

            var first = persons.First(person => person.Id == 3);

            Check.That(first).IsEqualTo(new Person(3, "Anne"));
        }

        [TestMethod]
        public void Should_throw_exception_when_no_element_found()
        {
            var persons = GetPersons();

            Check.ThatCode(
                () => persons.First(person => person.Id == 9))
                .Throws<InvalidOperationException>();
        }

        [TestMethod]
        public void Should_return_null_when_no_element_found()
        {
            var persons = GetPersons();

            var personFound = persons.FirstOrDefault(person => person.Id == 9);

            Check.That(personFound).IsNull();
        }

        [TestMethod]
        public void Should_default()
        {
            var persons = GetPersons();

            var personFound = persons.ElementAtOrDefault(9);

            Check.That(personFound).IsNull();
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
