using LocalPub.Models;
using LocalPub.Models.ViewModels;
using System.Collections.Generic;

namespace LocalPub.Domain.Interfaces
{
    public interface IMenuRepository : IDbRepository
    {
        MenuViewModel GetMenu();

        ICollection<MostWantedMenuItem> GetMostWantedMeals();

        ICollection<MenuItemDetails> GetMealsByDate();
    }
}
