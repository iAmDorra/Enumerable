using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class EqualityTest
    {
        [TestMethod]
        public void Should_return_true_when_two_collections_are_equal()
        {
            var persons = GetPersons();
            var otherPersons = GetPersons();

            var areEqual = persons.SequenceEqual(otherPersons);

            Check.That(areEqual).IsTrue();
        }

        [TestMethod]
        public void Should_return_true_when_two_collections_has_same_elements()
        {
            var persons = GetPersons();
            var otherPersons = GetOtherSamePersons();

            var areEqual = persons.SequenceEqual(otherPersons);

            Check.That(areEqual).IsTrue();
        }

        [TestMethod]
        public void Should_return_false_when_two_collections_has_same_elements_not_in_same_order()
        {
            var persons = GetPersons();
            var otherPersons = GetOtherSamePersonsWithDifferentOrder();

            var areEqual = persons.SequenceEqual(otherPersons);

            Check.That(areEqual).IsFalse();
        }

        [TestMethod]
        public void Should_return_false_when_two_collections_are_not_equal()
        {
            var persons = GetPersons();
            var otherPersons = new List<Person>
            {
                new Person(9, "Juliette")
            };

            var areEqual = persons.SequenceEqual(otherPersons);

            Check.That(areEqual).IsFalse();
        }

        private IEnumerable<Person> GetPersons()
        {
            yield return new Person(2, "Lucie");
            yield return new Person(4, "Laura");
            yield return new Person(1, "Arnaud");
            yield return new Person(3, "Anne");
        }
        private IEnumerable<Person> GetOtherSamePersons()
        {
            yield return new Person(2, "Lucie");
            yield return new Person(4, "Laura");
            yield return new Person(1, "Arnaud");
            yield return new Person(3, "Anne");
        }
        private IEnumerable<Person> GetOtherSamePersonsWithDifferentOrder()
        {
            yield return new Person(1, "Arnaud");
            yield return new Person(3, "Anne");
            yield return new Person(2, "Lucie");
            yield return new Person(4, "Laura");
        }
    }
}
