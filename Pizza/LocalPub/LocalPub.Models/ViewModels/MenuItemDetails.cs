using System;
using System.Collections.Generic;

namespace LocalPub.Models.ViewModels
{
    public class MenuItemDetails
    {
        public MenuItemDetails(DateTime orderDate, string mealName)
        {
            this.OrderDate = orderDate;
            this.MealName = mealName;
            this.ClientNames = new List<string>();
        }

        public DateTime OrderDate { get; private set; }

        public string MealName { get; private set; }

        public int MealsCount { get; set; }

        public ICollection<string> ClientNames { get; private set; }
    }
}
