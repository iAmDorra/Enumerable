using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class SkipDeleteTest
    {
        private List<Person> persons;

        [TestInitialize]
        public void Initialize()
        {
            persons = GetPerons();
        }

        [TestMethod]
        public void Should_return_less_elements_than_expected()
        {
            var newPersonSequence = persons.Skip(1);
            // Waiting to skip only Person(2,"Lucie") 
            // => newPersonSequence should contains Person(4, "Laura") and Person(1, "Arnaud")
            RemoveElement();

            // newPersonSequence is not calculated yet, so the remove should be applicated before
            Check.That(newPersonSequence.Count()).IsEqualTo(1);
            Check.That(newPersonSequence).Contains(new Person(1, "Arnaud"));
        }

        private void RemoveElement()
        {
            persons.RemoveAt(0);
        }

        private static List<Person> GetPerons()
        {
            return new List<Person>
            {
                new Person(2, "Lucie"),
                new Person(4, "Laura"),
                new Person(1, "Arnaud")
            };
        }
    }
}
