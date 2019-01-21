using System;
using System.Collections.Generic;
using System.Text;
using WhereToStudy.Model;

namespace WhereToStudy.Repository
{
    public class UsersRepository : BaseRepository
    {
        public User GetUser(User user)
        {
            return QueryFirst<User>("spGetUser", new { userName = user.UserName, password = user.Password });
        }

        public List<User> GetAllUsers()
        {
            return QueryMultiple<User>("spGetAllUsets");
        }

        public User InsertUser(User user)
        {
            return QueryFirst<User>("spInsertUser", new { userName = user.UserName, email = user.Email, password = user.Password, isAdmin = user.IsAdmin });
        }

        public User UpdateUser(User user)
        {
            return QueryFirst<User>("spUpdateUser", new { userName = user.UserName, email = user.Email, password = user.Password, isAdmin = user.IsAdmin });
        }

    }
}
