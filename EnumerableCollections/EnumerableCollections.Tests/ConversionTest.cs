using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class ConversionTest
    {
        [TestMethod]
        public void Should_cast_arraylist_to_enumerable()
        {
            ArrayList names = GetNames();

            var result = names.Cast<string>();

            Check.That(result.Count()).IsEqualTo(names.Count);
        }

        [TestMethod]
        public void Should_filter_elements()
        {
            IEnumerable<Animal> animals = GetAnimals();

            var result = animals.OfType<Cat>();

            int catNumber = 3;
            Check.That(result.Count()).IsEqualTo(catNumber);
        }

        [TestMethod]
        public void Should_Convert_ienumerable()
        {
            List<Animal> animals = new List<Animal>
            {
                new Animal()
            };

            var result = animals.AsEnumerable<Animal>();

            Check.That(result.Count()).IsEqualTo(animals.Count);
        }

        [TestMethod]
        public void Should_Create_default_element()
        {
            List<Animal> animals = new List<Animal>();

            var result = animals.DefaultIfEmpty<Animal>();

            int oneElementCreated = 1;
            Check.That(result.Count()).IsEqualTo(oneElementCreated);
        }

        private IEnumerable<Animal> GetAnimals()
        {
            yield return new Animal();
            yield return new Cat();
            yield return new Animal();
            yield return new Cat();
            yield return new Cat();
        }

        private ArrayList GetNames()
        {
            ArrayList names = new ArrayList();
            names.Add("Julie");
            names.Add("Mathilde");
            names.Add("Emilie");
            return names;
        }
    }
}
