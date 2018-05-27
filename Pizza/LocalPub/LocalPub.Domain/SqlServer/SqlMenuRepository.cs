using LocalPub.Domain.Interfaces;
using LocalPub.Models;
using LocalPub.Models.ViewModels;
using LocalPub.Utilities;
using System;
using System.Collections.Generic;

namespace LocalPub.Domain.SqlServer
{
    public class SqlMenuRepository : DbRepository, IMenuRepository
    {
        public SqlMenuRepository()
        {
        }

        public SqlMenuRepository(string connectionString)
            : base(connectionString)
        {
        }

        public MenuViewModel GetMenu()
        {
            var reader = this.ExecuteReader(
                    @"select
	                    mt.Name as MealType,
	                    m.Id as MealId,
	                    m.Name as MealName
                    from Meals as m
                    join MealTypes as mt
                    on m.MealTypeId = mt.Id");

            var appetizers = new List<MealDescription>();
            var mainCourses = new List<MealDescription>();
            var desserts = new List<MealDescription>();
            using (reader)
            {
                while (reader.Read())
                {
                    string mealTypeName = reader.GetString(0);
                    int mealId = reader.GetInt32(1);
                    string mealName = reader.GetString(2);
                    var meal = new MealDescription(mealId, mealName);
                    switch (mealTypeName)
                    {
                        case "Предястие":
                            appetizers.Add(meal);
                            break;
                        case "Основно ястие":
                            mainCourses.Add(meal);
                            break;
                        case "Десерт":
                            desserts.Add(meal);
                            break;
                        default:
                            throw new InvalidOperationException("No such meal type: " + mealTypeName);
                    }
                }
            }

            MenuViewModel menu = new MenuViewModel(appetizers, mainCourses, desserts);
            return menu;
        }

        public ICollection<MostWantedMenuItem> GetMostWantedMeals()
        {
            var reader = this.ExecuteReader(
                    @"select top 5
	                    m.Name,
	                    count(om.OrderId) as OrdersCount
                    from Meals as m
                    join OrderMeals as om
                    on om.MealId = m.Id
                    group by m.Name
                    order by OrdersCount desc");

            var meals = new List<MostWantedMenuItem>();
            using (reader)
            {
                while (reader.Read())
                {
                    string mealName = reader.GetString(0);
                    int ordersCount = reader.GetInt32(1);
                    meals.Add(new MostWantedMenuItem(mealName, ordersCount));
                }
            }

            return meals;
        }

        public ICollection<MenuItemDetails> GetMealsByDate()
        {
            var reader = this.ExecuteReader(
                    @"select 
	                     mealCounts.OrderDate, 
	                     mealCounts.MealName,
	                     mealCounts.MealsCount,
	                     c.Username,
	                     c.Name as ClientName
                    from (
	                    select 
		                    o.OrderDate,
		                    o.ClientId, 
		                    m.Name as MealName,
		                    count(o.ClientId) as MealsCount
	                    from Meals as m
	                    join OrderMeals as om
	                    on om.MealId = m.Id
	                    join Orders as o
	                    on om.OrderId = o.Id
	                    where o.IsCancelled = 0
	                    group by o.OrderDate, m.Name, o.ClientId) as mealCounts
                    join Clients as c
                    on mealCounts.ClientId = c.Id
                    order by mealCounts.OrderDate, mealCounts.MealName, mealCounts.ClientId");

            var meals = new Dictionary<Tuple<DateTime, string>, MenuItemDetails>();
            using (reader)
            {
                while (reader.Read())
                {
                    DateTime orderDate = reader.GetDateTime(0);
                    string mealName = reader.GetString(1);
                    int mealsCount = reader.GetInt32(2);
                    string username = reader.GetString(3);
                    string clientName = reader.GetString(4);

                    string clientNameRepresentation =
                        string.Format("{0} ({1})",
                        string.IsNullOrEmpty(clientName) ? "[no name]" : clientName,
                        username);

                    var key = new Tuple<DateTime, string>(orderDate, mealName);
                    if (!meals.ContainsKey(key))
                    {
                        meals[key] = new MenuItemDetails(orderDate, mealName);
                    }

                    meals[key].ClientNames.Add(clientNameRepresentation);
                    meals[key].MealsCount += mealsCount;
                }
            }

            return meals.Values;
        }
    }
}
