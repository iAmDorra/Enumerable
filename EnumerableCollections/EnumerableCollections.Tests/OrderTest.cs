using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void Order_collection_with_primitive_type()
        {
            IEnumerable<string> names = new List<string>() {
                "Arnauld",
                "Olfa",
                "Mathilde",
                "Tom"
            };

            var orderedNames = names.OrderBy(name => name);

            Check.That(orderedNames)
                 .ContainsExactly("Arnauld", "Mathilde", "Olfa", "Tom");
        }

        [TestMethod]
        public void Order_collection_with_objects()
        {
            IEnumerable<Person> persons = new List<Person>()
            {
                new Person(4, "Tom"),
                new Person(3, "Arnauld"),
                new Person(1, "Arnauld"),
                new Person(2, "Olfa"),
            };

            var orderedNames = persons.OrderBy(person => person.Name);

            Check.That(orderedNames)
                .ContainsExactly(
                new Person(3, "Arnauld"), 
                new Person(1, "Arnauld"),
                new Person(2, "Olfa"),
                new Person(4, "Tom"));
        }
    }
}
