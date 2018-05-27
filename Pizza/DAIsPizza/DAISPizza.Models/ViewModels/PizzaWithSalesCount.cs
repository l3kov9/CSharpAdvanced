namespace DAISPizza.Models.ViewModels
{
    public class PizzaWithSalesCount : Models.Pizza
    {
        public PizzaWithSalesCount(int id, string name, string description, string pictureUrl, int sales)
            : base(id, name, description, pictureUrl)
        {
            this.Sales = sales;
        }

        public int Sales { get; private set; }
    }
}
