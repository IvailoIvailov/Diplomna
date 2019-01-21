using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.vModel;
using Warehouse.vRepository;

namespace Warehouse.vServices
{
    public class UserService
    {
        private UsersRepository userRepository;

        public UserService()
        {
            userRepository = new UsersRepository();
        }

        public User GetUser(User user)
        {
            return userRepository.GetUser(user);
        }


        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
        public User UpdateUser(User user)
        {
            return userRepository.UpdateUser(user);
        }

        public User InsertUser(User user)
        {
            return userRepository.InsertUser(user);
        }

    }
}
