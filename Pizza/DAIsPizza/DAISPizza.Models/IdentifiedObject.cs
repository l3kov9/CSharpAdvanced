namespace DAISPizza.Models
{
    public abstract class IdentifiedObject
    {
        public IdentifiedObject(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as IdentifiedObject;
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); 
        }
    }
}
