namespace EnumerableCollections.Tests
{
    internal class Child
    {
        private int id;
        private string parentName;
        private string childName;

        public Child(int id, string parentName, string childName)
        {
            this.id = id;
            this.parentName = parentName;
            this.childName = childName;
        }

        public override bool Equals(object obj)
        {
            var child = obj as Child;
            return child != null
                && child.id == this.id
                && child.parentName == this.parentName
                && child.childName == this.childName;
        }
    }
}