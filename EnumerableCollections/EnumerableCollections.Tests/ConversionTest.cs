﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void Should_convert_to_Array()
        {
            var animals = GetAnimals();

            var animalsArray = animals.ToArray();

            Check.That(animalsArray).IsInstanceOfType(typeof(Animal[]));
        }

        [TestMethod]
        public void Should_convert_to_List()
        {
            var animals = GetAnimals();

            var animalsList = animals.ToList();

            Check.That(animalsList).IsInstanceOfType(typeof(List<Animal>));
        }

        [TestMethod]
        public void Should_convert_to_Dictionary()
        {
            var persons = GetPersonsWithUniqueIds();

            var personsDico = persons.ToDictionary(person => person.Id);

            Check.That(personsDico).IsInstanceOfType(typeof(Dictionary<int, Person>));
        }

        [TestMethod]
        public void Should_convert_to_Lookup()
        {
            var persons = GetPersonsWithSameIds();

            var personsLookup = persons.ToLookup(person => person.Id);

            Check.That(personsLookup).IsInstanceOfType(typeof(Lookup<int, Person>));

            const int idToFind = 2;
            var personsFound = personsLookup[idToFind];
            Check.That(personsFound).Contains(persons.Where(person => person.Id == idToFind));
        }

        private IEnumerable<Person> GetPersonsWithSameIds()
        {
            yield return new Person(1, "Lucie");
            yield return new Person(3, "Laura");
            yield return new Person(1, "Arnaud");
            yield return new Person(3, "Anne");
            yield return new Person(3, "Mathilde");
            yield return new Person(2, "Laurent");
        }

        private IEnumerable<Person> GetPersonsWithUniqueIds()
        {
            yield return new Person(2, "Lucie");
            yield return new Person(4, "Laura");
            yield return new Person(1, "Arnaud");
            yield return new Person(3, "Anne");
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
