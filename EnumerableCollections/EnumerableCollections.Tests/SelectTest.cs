using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class SelectTest
    {
        [TestMethod]
        public void Returns_persons_children()
        {
            var persons = GetPersons();
            IEnumerable<Person> children = persons.SelectMany(person => person.Childs);

            Check.That(children).ContainsExactly(new Person("Tom"), new Person("Fatou"));
        }

        private IEnumerable<Person> GetPersons()
        {

            Person aline = new Person("Aline");
            Person tom = new Person("Tom");
            aline.Childs.Add(tom);
            
            Person fen = new Person("Fen");

            Person fatou = new Person("Fatou");
            Person amine = new Person("Amine");
            amine.Childs.Add(fatou);
            return new List<Person> {
                aline,
                fen,
                amine};
        }
    }
}
