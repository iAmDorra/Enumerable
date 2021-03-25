using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class GenerationTest
    {
        [TestMethod]
        public void Should_create_a_range()
        {
            int elementNumber = 10;
            var result = Enumerable.Range(3, elementNumber);

            Check.That(result.Count()).IsEqualTo(elementNumber);
        }

        [TestMethod]
        public void Should_repeat_same_value()
        {
            int elementNumber = 10;
            const int repeatableValue = 3;
            var result = Enumerable.Repeat(repeatableValue, elementNumber);

            Check.That(result.Count()).IsEqualTo(elementNumber);
            Check.That(result.All(e => e == repeatableValue)).IsTrue();
        }

        [TestMethod]
        public void Should_create_an_empty_collection()
        {
            var result = Enumerable.Empty<Animal>();

            Check.That(result.Count()).IsEqualTo(0);
        }
    }
}
