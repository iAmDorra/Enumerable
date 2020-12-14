using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class EnumerableTest
    {
        [TestMethod]
        public void If_the_enumeration_is_not_calculated_its_values_may_be_changed_when_the_original_collection_is_modified()
        {
            var names = GetNames();
            IEnumerable<string> partNames = names.Where(n => n.Contains("to"));

            Check.That(partNames).ContainsExactly("Fatou", "Jackito", "Ritom");

            names.Add("Halima");
            names.Add("Amirato");

            Check.That(partNames).ContainsExactly("Fatou", "Jackito", "Ritom", "Amirato");

            names.Remove("Ritom");
            names.Remove("Amirato");

            Check.That(partNames).ContainsExactly("Fatou", "Jackito");
        }

        [TestMethod]
        public void If_the_enumeration_is_calculated_its_values_should_not_be_changed_when_the_original_collection_is_modified()
        {
            var names = GetNames();
            IEnumerable<string> partNames = names.Where(n => n.Contains("to")).ToList();

            Check.That(partNames).ContainsExactly("Fatou", "Jackito", "Ritom");

            names.Add("Halima");
            names.Add("Amirato");

            Check.That(partNames).ContainsExactly("Fatou", "Jackito", "Ritom");

            names.Remove("Ritom");
            names.Remove("Amirato");

            Check.That(partNames).ContainsExactly("Fatou", "Jackito", "Ritom");
        }

        private List<string> GetNames()
        {
            return new List<string> {"Aline", "Tom", "Fen", "Fatou",
                "Amine", "Jackito", "Ritom", "Yosr", "Cyril", "Olfa",
                "Mathilde", "Karim"};
        }
    }
}
