namespace ExternalLib
{
    public class RelayPoint
    {
        private int id;
        private string name;

        public RelayPoint(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id => id;
        public string Name => name;
    }
}