using System.Collections.Generic;
using DAISPizza.Models;
using DAISPizza.Models.ViewModels;
using DAISPizza.Services.Interfaces;
using DAISPizza.Services.SqlServer;

namespace DAISPizza.Services
{
    public class PizzaManager
    {
        private IPizzaRepository pizzaRepository;

        public PizzaManager()
            : this(new SqlPizzaRepository())
        {
        }

        public PizzaManager(IPizzaRepository pizzaRepository)
        {
            this.pizzaRepository = pizzaRepository;
        }

        public ICollection<PizzaWithIngredients> GetPizzas()
        {
            return this.pizzaRepository.GetPizzasWithIngredients();
        }

        public PizzaOrderViewModel GetPizzaToOrder(int id)
        {
            using (this.pizzaRepository)
            {
                var pizzaInfo = this.pizzaRepository.GetPizza(id);
                var doughTypes = this.pizzaRepository.GetAllDoughTypes();
                var sizes = this.pizzaRepository.GetAllSizes();
                var allIngredients = this.pizzaRepository.GetAllIngredients();
                var pizzaIngredients = this.pizzaRepository.GetAllPizzaIngredients(id);
                var orderIngredients = this.MergeIngredients(allIngredients, pizzaIngredients);
                return new PizzaOrderViewModel(
                    pizzaInfo.Id,
                    pizzaInfo.Name, 
                    pizzaInfo.Description,
                    pizzaInfo.PictureUrl,
                    doughTypes,
                    sizes, 
                    orderIngredients);
            }
        }

        public PizzaWithSalesCount GetMostWantedPizza()
        {
            return this.pizzaRepository.GetMostWantedPizza();
        }

        private ICollection<IngredientInOrderDescription> MergeIngredients(
            ICollection<PizzaIngredientDescription> allIngredients,
            ICollection<PizzaIngredientDescription> pizzaIngredients)
        {
            var orderIngredients = new Dictionary<int, IngredientInOrderDescription>();
            foreach (var ingredient in allIngredients)
            {
                orderIngredients[ingredient.Id] = new IngredientInOrderDescription(ingredient.Id, ingredient.Name, false);
            }

            foreach (var pizzaIngredient in pizzaIngredients)
            {
                orderIngredients[pizzaIngredient.Id].IsSelected = true;
            }

            return orderIngredients.Values;
        }
    }
}
