using System.Collections.Generic;

namespace EnumerableCollections.Tests
{
    internal class Group
    {
        private int id;
        private IEnumerable<Person> childs;

        public Group(int id, IEnumerable<Person> childs)
        {
            this.id = id;
            this.childs = childs;
        }
    }
}