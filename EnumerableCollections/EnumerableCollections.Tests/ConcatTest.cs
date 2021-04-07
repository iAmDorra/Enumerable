using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class ConcatTest
    {
        [TestMethod]
        public void Should_concat_two_collections_with_same_type()
        {
            var persons = GetPersons();
            var otherPersons = GetOtherPersons();

            var allPersons = persons.Concat(otherPersons);

            Check.That(allPersons).CountIs(6);
        }

        [TestMethod]
        public void Should_not_concat_second_collection_is_null()
        {
            var persons = GetPersons();
            IEnumerable<Person> otherPersons = null;

            Check.ThatCode(() =>
            {
                var allPersons = persons.Concat(otherPersons);
            }).Throws<ArgumentNullException>();
        }

        private IEnumerable<Person> GetPersons()
        {
            yield return new Person(2, "Lucie");
            yield return new Person(4, "Laura");
            yield return new Person(1, "Arnaud");
            yield return new Person(3, "Anne");
        }
        private IEnumerable<Person> GetOtherPersons()
        {
            yield return new Person(2, "Olfa");
            yield return new Person(4, "Amine");
        }
    }
}
