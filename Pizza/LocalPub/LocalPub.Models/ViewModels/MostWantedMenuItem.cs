
namespace LocalPub.Models.ViewModels
{
    public class MostWantedMenuItem
    {
        public MostWantedMenuItem(string mealName, int ordersCount)
        {
            this.MealName = mealName;
            this.OrdersCount = ordersCount;
        }

        public string MealName { get; private set; }

        public int OrdersCount { get; private set; }
    }
}
