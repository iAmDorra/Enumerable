using System.Collections.Generic;

namespace EnumerableCollections.Tests
{
    internal class Groupe
    {
        private int id;
        private IEnumerable<Person> childs;

        public Groupe(int id, IEnumerable<Person> childs)
        {
            this.id = id;
            this.childs = childs;
        }
    }
}