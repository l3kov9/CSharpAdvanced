using DAISPizza.Models.ViewModels;
namespace DAISPizza.Models
{
    public class IngredientInOrderDescription : PizzaIngredientDescription
    {
        public IngredientInOrderDescription(int id, string name, bool isSelected)
            : base(id, name)
        {
            this.IsSelected = isSelected;
        }

        public bool IsSelected { get; set; }
    }
}
