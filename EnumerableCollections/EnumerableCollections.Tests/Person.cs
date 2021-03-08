using System.Collections.Generic;

namespace EnumerableCollections.Tests
{
    internal class Person
    {
        private string name;
        private int id;

        public Person(string name)
        {
            this.name = name;
            Childs = new List<Person>();
        }

        public Person(int id, string name) :
            this(name)
        {
            this.id = id;
        }

        public string Name => name;

        public List<Person> Childs { get; private set; }

        public int Id => id;

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null
                && person.name == this.name
                && person.id == this.id;
        }

        public override string ToString()
        {
            return this.id + "-" + this.name;
        }
    }
}
