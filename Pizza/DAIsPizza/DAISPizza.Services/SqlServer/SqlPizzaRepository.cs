using System.Collections.Generic;
using DAISPizza.Models;
using DAISPizza.Models.ViewModels;
using DAISPizza.Services.Interfaces;

namespace DAISPizza.Services.SqlServer
{
    public class SqlPizzaRepository : DbRepository, IPizzaRepository
    {
        public SqlPizzaRepository(string connectionString)
            : base(connectionString)
        {
        }

        public SqlPizzaRepository()
            : base("Data Source=.;Integrated Security=True;Database=DAIsPizza")
        {
        }

        public ICollection<PizzaWithIngredients> GetPizzasWithIngredients()
        {
            var pizzas = new Dictionary<int, Models.ViewModels.PizzaWithIngredients>();
            using (this)
            {
                var reader = this.ExecuteReader(
                    @"select
	                    p.Id as PizzaId,
	                    p.Name as PizzaName,
	                    p.Description,
	                    p.PicturePath,
	                    i.Id as IngredientId,
	                    i.Name as IngredientName
                    from Pizzas as p
                    join Pizzas_Ingredients as [pi]
                    on [pi].PizzaId = p.Id
                    join Ingredients as i
                    on pi.IngredientId = i.Id");
                using (reader)
                {
                    while (reader.Read())
                    {
                        int pizzaId = reader.GetInt32(0);
                        string pizzaName = reader.GetString(1);
                        string description = reader.GetString(2);
                        string picturePath = reader.GetString(3);
                        int ingredientId = reader.GetInt32(4);
                        string indgredientName = reader.GetString(5);

                        if (!pizzas.ContainsKey(pizzaId))
                        {
                            pizzas[pizzaId] = new Models.ViewModels.PizzaWithIngredients(pizzaId, pizzaName, description, picturePath);
                        }

                        pizzas[pizzaId].Ingredients.Add(new PizzaIngredientDescription(ingredientId, indgredientName));
                    }
                }
                return pizzas.Values;
            }
        }

        public Pizza GetPizza(int id)
        {
            Pizza pizza = null;
            var reader = this.ExecuteReader(
                @"select
	                p.Id as PizzaId,
	                p.Name as PizzaName,
	                p.Description,
	                p.PicturePath
                from Pizzas as p
                where p.Id = @pizzaId",
                new Dictionary<string, object>()
                {
                        { "@pizzaId", id }
                });
            using (reader)
            {
                while (reader.Read())
                {
                    int pizzaId = reader.GetInt32(0);
                    string pizzaName = reader.GetString(1);
                    string description = reader.GetString(2);
                    string picturePath = reader.GetString(3);

                    if (pizza == null)
                    {
                        pizza = new Pizza(pizzaId, pizzaName, description, picturePath);
                    }
                }
            }
            return pizza;
        }

        public PizzaWithIngredients GetPizzaWithIngredients(int id)
        {
            PizzaWithIngredients pizza = null;
            var reader = this.ExecuteReader(
                @"select
	                p.Id as PizzaId,
	                p.Name as PizzaName,
	                p.Description,
	                p.PicturePath,
	                i.Id as IngredientId,
	                i.Name as IngredientName
                from Pizzas as p
                join Pizzas_Ingredients as [pi]
                on [pi].PizzaId = p.Id
                join Ingredients as i
                on pi.IngredientId = i.Id
                where p.Id = @pizzaId",
                new Dictionary<string, object>()
                {
                        { "@pizzaId", id }
                });
            using (reader)
            {
                while (reader.Read())
                {
                    int pizzaId = reader.GetInt32(0);
                    string pizzaName = reader.GetString(1);
                    string description = reader.GetString(2);
                    string picturePath = reader.GetString(3);
                    int ingredientId = reader.GetInt32(4);
                    string indgredientName = reader.GetString(5);

                    if (pizza == null)
                    {
                        pizza = new PizzaWithIngredients(pizzaId, pizzaName, description, picturePath);
                    }

                    pizza.Ingredients.Add(new PizzaIngredientDescription(ingredientId, indgredientName));
                }
            }
            return pizza;
        }

        public PizzaWithSalesCount GetMostWantedPizza()
        {
            PizzaWithSalesCount pizza = null;
            using (this)
            {
                var reader = this.ExecuteReader(
                @"select top 1 p.Id, p.Name, p.Description, p.PicturePath, sales.Count
                from (select p.Id, count(po.PizzaId) as [Count]
		                from Pizzas p
		                join PizzaOrders po
		                on po.PizzaId = p.Id
		                group by p.Id) sales
                join Pizzas p
                on sales.Id = p.Id
                order by sales.Count desc");
                using (reader)
                {
                    while (reader.Read())
                    {
                        int pizzaId = reader.GetInt32(0);
                        string pizzaName = reader.GetString(1);
                        string description = reader.GetString(2);
                        string picturePath = reader.GetString(3);
                        int salesCount = reader.GetInt32(4);
                        pizza = new PizzaWithSalesCount(pizzaId, pizzaName, description, picturePath, salesCount);
                    }
                }
            }

            return pizza;
        }

        public ICollection<DoughTypeDescription> GetAllDoughTypes()
        {
            var doughTypes = new Dictionary<int, DoughTypeDescription>();
            var reader = this.ExecuteReader(
                @"select Id, Name
                from DoughTypes");
            using (reader)
            {
                while (reader.Read())
                {
                    int doughTypeId = reader.GetInt32(0);
                    string doughTypeName = reader.GetString(1);

                    if (!doughTypes.ContainsKey(doughTypeId))
                    {
                        doughTypes[doughTypeId] = new DoughTypeDescription(doughTypeId, doughTypeName);
                    }
                }
            }

            return doughTypes.Values;
        }

        public ICollection<SizeDescription> GetAllSizes()
        {
            var sizes = new Dictionary<int, SizeDescription>();
            var reader = this.ExecuteReader(
                @"select Id, Name
                    from Sizes");
            using (reader)
            {
                while (reader.Read())
                {
                    int sizeId = reader.GetInt32(0);
                    string sizeName = reader.GetString(1);

                    if (!sizes.ContainsKey(sizeId))
                    {
                        sizes[sizeId] = new SizeDescription(sizeId, sizeName);
                    }
                }
            }

            return sizes.Values;
        }

        public ICollection<PizzaIngredientDescription> GetAllIngredients()
        {
            var ingredients = new Dictionary<int, PizzaIngredientDescription>();
            var reader = this.ExecuteReader(
                @"select Id, Name
                    from Ingredients");
            using (reader)
            {
                while (reader.Read())
                {
                    int ingredientId = reader.GetInt32(0);
                    string ingredientName = reader.GetString(1);

                    if (!ingredients.ContainsKey(ingredientId))
                    {
                        ingredients[ingredientId] = new PizzaIngredientDescription(ingredientId, ingredientName);
                    }
                }
            }

            return ingredients.Values;
        }

        public ICollection<PizzaIngredientDescription> GetAllPizzaIngredients(int pizzaId)
        {
            var pizzaIngredients = new Dictionary<int, PizzaIngredientDescription>();
            var reader = this.ExecuteReader(
                @"select i.Id, i.Name
                from Pizzas as p
                join Pizzas_Ingredients as [pi]
                on [pi].PizzaId = p.Id
                join Ingredients as i
                on pi.IngredientId = i.Id
                where p.Id = @pizzaId",
                new Dictionary<string, object>()
                {
                    { "@pizzaId", pizzaId }
                });
            using (reader)
            {
                while (reader.Read())
                {
                    int ingredientId = reader.GetInt32(0);
                    string ingredientName = reader.GetString(1);

                    if (!pizzaIngredients.ContainsKey(ingredientId))
                    {
                        pizzaIngredients[ingredientId] = new PizzaIngredientDescription(ingredientId, ingredientName);
                    }
                }
            }

            return pizzaIngredients.Values;
        }
    }
}
