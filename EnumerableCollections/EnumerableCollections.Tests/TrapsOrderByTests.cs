using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class TrapsOrderByTests
    {
        [TestMethod]
        public void No_OrderBy_Deferred()
        {
            IEnumerable<long> GetEnumerable()
            {
                Console.WriteLine("Generating Enumerable");
                return Enumerable.Range(1, 1000000)
                    .Select(i => (long)i);
            }

            var unsortedEnumerable = GetEnumerable();

            var x1 = unsortedEnumerable.Sum();
            var x2 = unsortedEnumerable.Sum();
        }

        [TestMethod]
        public void No_OrderBy_Resolved()
        {
            IEnumerable<long> GetEnumerable()
            {
                Console.WriteLine("Generating Enumerable");
                return Enumerable.Range(1, 1000000)
                    .Select(i => (long)i);
            }

            var unsortedEnumerable = GetEnumerable().ToArray();

            var x1 = unsortedEnumerable.Sum();
            var x2 = unsortedEnumerable.Sum();
        }

        [TestMethod]
        public void Multiple_OrderBy()
        {
            IEnumerable<long> GetEnumerable()
            {
                Console.WriteLine("Generating Enumerable");
                return Enumerable.Range(1, 1000000)
                    .Select(i => (long)i)
                    .OrderByDescending(x => x);
            }

            var deferredEnumerable = GetEnumerable();

            var x1 = deferredEnumerable.Sum();
            var x2 = deferredEnumerable.Sum();
        }

        [TestMethod]
        public void Resolved_OrderBy()
        {
            IEnumerable<long> GetEnumerable()
            {
                Console.WriteLine("Generating Enumerable");
                return Enumerable.Range(1, 1000000).Select(i => (long)i).OrderByDescending(x => x);
            }

            var deferredEnumerable = GetEnumerable().ToArray();

            var x1 = deferredEnumerable.Sum();
            var x2 = deferredEnumerable.Sum();
        }
    }
}