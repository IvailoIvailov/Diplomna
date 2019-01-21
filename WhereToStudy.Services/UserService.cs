using System;
using System.Collections.Generic;
using System.Text;
using WhereToStudy.vModel;
using WhereToStudy.vRepository;

namespace WhereToStudy.Services
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
