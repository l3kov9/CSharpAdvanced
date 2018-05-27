using System.Collections.Generic;

namespace DAISPizza.Models.ViewModels
{
    public class PizzaOrderViewModel : Pizza
    {
        public PizzaOrderViewModel(
            int id,
            string name,
            string description,
            string pictureUrl,
            ICollection<DoughTypeDescription> doughTypes,
            ICollection<SizeDescription> sizes,
            ICollection<IngredientInOrderDescription> allIngredients)
            : base(id, name, description, pictureUrl)
        {
            this.DoughTypes = doughTypes;
            this.Sizes = sizes;
            this.AllIngredients = new List<IngredientInOrderDescription>(allIngredients);
        }

        public ICollection<DoughTypeDescription> DoughTypes { get; set; }

        public ICollection<SizeDescription> Sizes { get; set; }

        public ICollection<IngredientInOrderDescription> AllIngredients { get; set; }
    }
}
