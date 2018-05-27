using DAISPizza.Models;

namespace DAISPizza.Services.Interfaces
{
    public interface IUserRepository : IDbRepository
    {
        int GetUsersCountByUsername(string username);

        void CreateUser(UserCreationModel user);

        User GetUserByUsername(string username);
    }
}
