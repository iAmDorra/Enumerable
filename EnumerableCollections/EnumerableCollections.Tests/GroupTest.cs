using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class GroupTest
    {
        [TestMethod]
        public void Should_group_parents_by_name()
        {
            IEnumerable<Parent> parents = GetParents();

            var groupedParents = parents.GroupBy(parent => parent.Name);

            const int DifferentNamesNumber = 3; //Emilie, Arnaud, Julie
            Check.That(groupedParents.Count()).IsEqualTo(DifferentNamesNumber);
        }

        [TestMethod]
        public void Should_group_parents_ids_by_name()
        {
            IEnumerable<Parent> parents = GetParents();

            var groupedParents = parents.GroupBy(parent => parent.Name, parent => parent.Id);

            const int DifferentNamesNumber = 3; //Emilie, Arnaud, Julie
            Check.That(groupedParents.Count()).IsEqualTo(DifferentNamesNumber);
        }

        private IEnumerable<Parent> GetParents()
        {
            yield return new Parent(1, "Emilie");
            yield return new Parent(2, "Arnaud");
            yield return new Parent(3, "Julie");
            yield return new Parent(4, "Arnaud");
            yield return new Parent(5, "Julie");
            yield return new Parent(6, "Julie");
        }
    }
}
