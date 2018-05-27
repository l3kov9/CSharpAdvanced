using System;
using System.Collections.Generic;
using DAISPizza.Models;
using DAISPizza.Models.ViewModels;

namespace DAISPizza.Services.Interfaces
{
    public interface IPizzaRepository : IDbRepository
    {
        ICollection<PizzaWithIngredients> GetPizzasWithIngredients();

        Pizza GetPizza(int id);

        PizzaWithIngredients GetPizzaWithIngredients(int id);

        PizzaWithSalesCount GetMostWantedPizza();

        ICollection<DoughTypeDescription> GetAllDoughTypes();

        ICollection<SizeDescription> GetAllSizes();

        ICollection<PizzaIngredientDescription> GetAllIngredients();

        ICollection<PizzaIngredientDescription> GetAllPizzaIngredients(int pizzaId);
    }
}
