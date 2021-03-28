using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class QuantifierTest
    {
        [TestMethod]
        public void Should_return_true_when_collection_has_elements()
        {
            var persons = GetPersons();

            var elementExists = persons.Any();

            Check.That(elementExists).IsTrue();
        }

        [TestMethod]
        public void Should_return_false_when_no_element_found()
        {
            var persons = GetPersons();

            var elementExists = persons.Any(person => person.Id == 9);

            Check.That(elementExists).IsFalse();
        }

        [TestMethod]
        public void Should_return_true_when_all_persons_names_starts_with_L()
        {
            var persons = GetPersonsStartingWithL();

            var allPersonsStartsWithL = persons.All(person => person.Name.StartsWith('L'));

            Check.That(allPersonsStartsWithL).IsTrue();
        }

        [TestMethod]
        public void Should_return_true_when_contains_elements()
        {
            var persons = GetPersons();

            var allPersonsStartsWithL = persons.Contains(new Person(3, "Anne"));

            Check.That(allPersonsStartsWithL).IsTrue();
        }

        private IEnumerable<Person> GetPersons()
        {
            yield return new Person(2, "Lucie");
            yield return new Person(4, "Laura");
            yield return new Person(1, "Arnaud");
            yield return new Person(3, "Anne");
        }

        private IEnumerable<Person> GetPersonsStartingWithL()
        {
            yield return new Person(2, "Lucie");
            yield return new Person(4, "Laura");
        }
    }
}
