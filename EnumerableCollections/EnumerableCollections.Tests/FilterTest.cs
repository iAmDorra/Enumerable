using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class FilterTest
    {
        [TestMethod]
        public void Linq_Filter_Order_IEnumerable()

        {
            IEnumerable<string> enumerable = new List<string>() {
                "Cyril",
                "Olfa",
                "Mathilde",
                "Karim",
            };

            var filteredAndOrdered =
                from person in enumerable
                where person.Contains("i")
                orderby person
                select person;

            Check.That(filteredAndOrdered)
                 .ContainsExactly("Cyril", "Karim", "Mathilde");
        }

        [TestMethod]
        public void Linq_Method_Filter_Order_IEnumerable()
        {
            IEnumerable<string> enumerable = new List<string>() {
                "Cyril",
                "Olfa",
                "Mathilde",
                "Karim",
            };

            var filteredAndOrdered = enumerable
                .Where(person => person.Contains("i"))
                .OrderBy(person => person);

            Check.That(filteredAndOrdered)
                .ContainsExactly("Cyril", "Karim", "Mathilde");
        }
    }
}
