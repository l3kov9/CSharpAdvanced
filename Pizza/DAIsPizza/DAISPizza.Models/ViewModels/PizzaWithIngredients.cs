using System.Collections.Generic;

namespace DAISPizza.Models.ViewModels
{
    public class PizzaWithIngredients : Pizza
    {
        public PizzaWithIngredients(int id, string name, string description, string pictureUrl)
            : base(id, name, description, pictureUrl)
        {
            this.Ingredients = new List<PizzaIngredientDescription>();
        }

        public ICollection<PizzaIngredientDescription> Ingredients { get; private set; }
    }
}
