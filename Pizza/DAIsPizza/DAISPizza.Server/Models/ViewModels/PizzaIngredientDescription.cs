using DAISPizza.Models;

namespace DAISPizza.Server.Models.ViewModels
{
    public class PizzaIngredientDescription : IdentifiedObject
    {
        public PizzaIngredientDescription(int id, string name)
            : base(id)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
