using LocalPub.Domain.Interfaces;
using LocalPub.Domain.SqlServer;
using LocalPub.Models.ViewModels;
using System.Collections.Generic;

namespace LocalPub.Domain.Managers
{
    public class MenuManager
    {
        private IMenuRepository menuRepository;

        public MenuManager()
            : this(new SqlMenuRepository())
        {
        }

        public MenuManager(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public ICollection<MostWantedMenuItem> GetMostWantedMeals()
        {
            return this.menuRepository.GetMostWantedMeals();
        }

        public ICollection<MenuItemDetails> GetMealsByDate()
        {
            return this.menuRepository.GetMealsByDate();
        }
    }
}
