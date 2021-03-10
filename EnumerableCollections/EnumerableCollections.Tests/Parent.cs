namespace EnumerableCollections.Tests
{
    internal class Parent
    {
        private readonly int id;
        private readonly string name;

        public Parent(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string Name => name;

        public int Id => id;
    }
}