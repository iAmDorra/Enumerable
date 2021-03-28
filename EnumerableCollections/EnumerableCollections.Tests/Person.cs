using System.Collections.Generic;

namespace EnumerableCollections.Tests
{
    public class Person
    {
        private string name;
        private int id;

        public Person(string name)
        {
            this.name = name;
            Children = new List<Person>();
        }

        public Person(int id, string name) :
            this(name)
        {
            this.id = id;
        }

        public string Name => name;

        public List<Person> Children { get; }

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
