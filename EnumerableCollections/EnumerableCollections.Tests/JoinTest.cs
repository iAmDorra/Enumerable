using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class JoinTest
    {
        [TestMethod]
        public void Should_join_collections()
        {
            IEnumerable<Person> persons = new List<Person>
            {
                new Person(4, "Tom"),
                new Person(3, "Arnauld"),
                new Person(1, "Laurent"),
                new Person(2, "Olfa"),
            };
            IEnumerable<Parent> parents = new List<Parent>
            {
                new Parent(1,"Anne"),
                new Parent(4,"Céline"),
                new Parent(3,"Nicolas")
            };

            var result = parents.Join(persons, parent => parent.Id, person => person.Id, (parent, person) =>
            new Child(person.Id, parent.Name, person.Name)); ;

            Check.That(result).ContainsExactly(
                new Child(1, "Anne", "Laurent"),
                new Child(4, "Céline", "Tom"),
                new Child(3, "Nicolas", "Arnauld"));
        }

        [TestMethod]
        public void Should_group_join_collections()
        {
            IEnumerable<Person> persons = new List<Person>
            {
                new Person(4, "Tom"),
                new Person(3, "Arnauld"),
                new Person(1, "Laurent"),
                new Person(1, "Alice"),
                new Person(2, "Olfa"),
            };
            IEnumerable<Parent> parents = new List<Parent>
            {
                new Parent(1,"Anne"),
                new Parent(4,"Céline"),
                new Parent(3,"Nicolas")
            };

            var result = parents.GroupJoin(persons, parent => parent.Id, person => person.Id, (parent, childs) => new Groupe(parent.Id, childs))
                .ToList();

            Check.That(result).CountIs(3);
        }
    }
}
