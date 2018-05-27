using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAISPizza.Models;
using DAISPizza.Models.BindingModels;
using DAISPizza.Services.Interfaces;
using DAISPizza.Services.SqlServer;
using DAISPizza.Utilities;

namespace DAISPizza.Services
{
    public class UserManager
    {
        private IUserRepository userRepository;

        public UserManager()
            : this(new SqlUserRepository())
        {
        }

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(RegisterUserBindingModel user)
        {
            int existingUsersCount = this.userRepository.GetUsersCountByUsername(user.Username);
            if (existingUsersCount != 0)
            {
                throw new InvalidOperationException("There is already a user with the same username.");
            }

            var passwordSalt = PasswordUtilities.GeneratePasswordSalt();
            var passwordHash = PasswordUtilities.GeneratePasswordHash(user.Password, passwordSalt);
            try
            {
                var userCreationModel = new UserCreationModel(user.Username, user.Address, user.Phone, passwordHash, passwordSalt);
                this.userRepository.CreateUser(userCreationModel);
            }
            catch (SqlException)
            {
                throw new InvalidOperationException("Unable to insert the user into the database.");
            }
        }

        public User GetUser(LoginUserBindingModel user)
        {
            var userResult = this.userRepository.GetUserByUsername(user.Username);
            if (userResult == null)
            {
                throw new InvalidOperationException("There's no such user with the provided username.");
            }

            var actualPasswordHash = PasswordUtilities.GeneratePasswordHash(user.Password, userResult.PasswordSalt);
            if (actualPasswordHash != userResult.PasswordHash)
            {
                throw new ArgumentException("The passwords don't match.");
            }

            return userResult;
        }
    }
}
