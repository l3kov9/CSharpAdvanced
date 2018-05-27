namespace DAISPizza.Models
{
    public class Pizza : IdentifiedObject
    {
        public Pizza(int id, string name, string description, string pictureUrl)
            : base(id)
        {
            this.Name = name;
            this.Description = description;
            this.PictureUrl = pictureUrl;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}
