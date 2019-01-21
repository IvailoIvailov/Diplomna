using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.vModel;

namespace Warehouse.vRepository
{
    public class UsersRepository : BaseRepository
    {
        public User GetUser(User user)
        {
            return QueryFirst<User>("spGetUser", new { @pUserName = user.UserName, @pPassword = user.Password });
        }
        
        public User GetUserById(int id)
        {
            return QueryFirst<User>("GetUserById", new { @pId = id});
        }

        public List<User> GetAllUsers()
        {
            return QueryMultiple<User>("spGetAllUsers");
        }

        public User InsertUser(User user)
        {
            return QueryFirst<User>("spInsertUser", new
            {

                @pFirstName = user.FirstName
                ,
                @pSurName = user.SurName
                ,
                @pLastName = user.LastName
                ,
                @pUserName = user.UserName
                ,
                @pPassword = user.Password
                ,
                @pAddress = user.Address
                ,
                @pEmail = user.Email
                ,
                @pPhone = user.Phone
                ,
                @pGender = user.Gender
                ,
                @pAge = user.Age
                ,
                @pDate = user.Date
                ,
                @pIsAdmin = user.IsAdmin
            });
        }

        public User UpdateUser(User user)
        {
            return QueryFirst<User>("spUpdateUser", new
            {
                @pId = user.Id
                ,
                @pFirstName = user.FirstName
                ,
                @pSurName = user.SurName
                ,
                @pLastName = user.LastName
                ,
                @pUserName = user.UserName
                ,
                @pPassword = user.Password
                ,
                @pAddress = user.Address
                ,
                @pEmail = user.Email
                ,
                @pPhone = user.Phone
                ,
                @pGender = user.Gender
                ,
                @pAge = user.Age
                ,
                @pIsAdmin = user.IsAdmin
            });
        }

    }
}
