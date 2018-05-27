namespace DAISPizza.Models
{
    public class SizeDescription : IdentifiedObject
    {
        public SizeDescription(int id, string name)
            : base(id)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
