using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class InitializationOperationTest
    {
        [TestMethod]
        public void Should_distinct_names()
        {
            IEnumerable<string> names = GetNames();

            var distinctNames = names.Distinct();

            const int DistinctNamesNumber = 3; //Emilie, Arnaud, Julie
            Check.That(distinctNames.Count()).IsEqualTo(DistinctNamesNumber);
        }

        [TestMethod]
        public void Should_union_names()
        {
            IEnumerable<string> names = GetNames();
            List<string> otherNames = new List<string> { "Emmanuella", "Christophe" };

            var unionResult = names.Union(otherNames);

            var expectedNamesNumber = 5; // Emilie, Arnaud, Julie, Emmanuella, Christophe
            Check.That(unionResult.Count()).IsEqualTo(expectedNamesNumber);
        }

        [TestMethod]
        public void Should_intersect_names()
        {
            IEnumerable<string> names = GetNames();
            List<string> otherNames = new List<string> { "Julie", "Emilie" };

            var result = names.Intersect(otherNames);

            var expectedNamesNumber = 2; // Emilie, Julie
            Check.That(result.Count()).IsEqualTo(expectedNamesNumber);
        }

        [TestMethod]
        public void Should_returns_differences_between_collections()
        {
            IEnumerable<string> names = GetNames();
            List<string> otherNames = new List<string> { "Julie", "Emilie" };

            var result = names.Except(otherNames);

            var expectedNamesNumber = 1; // Arnaud
            Check.That(result.Count()).IsEqualTo(expectedNamesNumber);
        }

        private IEnumerable<string> GetNames()
        {
            yield return "Emilie";
            yield return "Arnaud";
            yield return "Julie";
            yield return "Arnaud";
            yield return "Julie";
            yield return "Julie";
        }
    }
}
