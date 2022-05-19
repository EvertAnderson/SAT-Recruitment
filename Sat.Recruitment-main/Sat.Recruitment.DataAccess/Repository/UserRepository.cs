using Sat.Recruitment.DataAccess.DataBase;
using Sat.Recruitment.DataAccess.Repository.IRepository;
using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sat.Recruitment.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> lUsers = new TxtReadWrite(ReadUsers.ReadUsersFromFile()).GetUserList();
        public User AddUser(User user)
        {
            lUsers.Add(user);
            return user;
        }

        public void DeleteUser(User user)
        {
            lUsers.Remove(user);
        }

        public User EditUser(User user)
        {
            var obj = GetUser(user.Name);
            obj.Name = user.Name;
            obj.Email = user.Email;
            obj.Address = user.Address;
            obj.Phone = user.Phone;
            obj.UserType = user.UserType;
            obj.Money = user.Money;
            return obj;
        }

        public User GetUser(string name)
        {
            return lUsers.FirstOrDefault(x => x.Name == name);
        }

        public List<User> GetUsers()
        {
            return lUsers;
        }
    }
}
