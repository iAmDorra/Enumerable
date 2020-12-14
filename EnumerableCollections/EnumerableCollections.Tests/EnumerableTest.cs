using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System.Collections.Generic;
using System.Diagnostics;
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

        [TestMethod]
        public void Should_have_same_execution_time_with_list_and_Enumerable_one()
        {
            var nameList = GetNames();
            var names = GetEnumerableNames();
            var result = new List<string> { "Fatou", "Jackito", "Ritom" };
            const string containgValue = "to";

            var listWatch = Stopwatch.StartNew();
            IEnumerable<string> partNameList = nameList.Where(n => n.Contains(containgValue));
            foreach (var item in partNameList)
            {
                result.Contains(item);
            }
            listWatch.Stop();
            var executionTimeUsingList = listWatch.ElapsedMilliseconds;

            var enumerableWatch = Stopwatch.StartNew();
            IEnumerable<string> partNames = names.Where(n => n.Contains(containgValue));
            foreach (var item in partNames)
            {
                result.Contains(item);
            }
            enumerableWatch.Stop();
            var executionTimeUsingEnumerable = enumerableWatch.ElapsedMilliseconds;

            Check.That(executionTimeUsingEnumerable).IsEqualTo(executionTimeUsingList);
        }

        private List<string> GetNames()
        {
            return new List<string> {"Aline", "Tom", "Fen", "Fatou",
                "Amine", "Jackito", "Ritom", "Yosr", "Cyril", "Olfa",
                "Mathilde", "Karim"};
        }

        private IEnumerable<string> GetEnumerableNames()
        {
            yield return "Aline";
            yield return "Tom";
            yield return "Fen";
            yield return "Fatou";
            yield return "Amine";
            yield return "Jackito";
            yield return "Ritom";
            yield return "Yosr";
            yield return "Cyril";
            yield return "Olfa";
            yield return "Mathilde";
            yield return "Karim";
        }
    }
}
