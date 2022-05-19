using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sat.Recruitment.DataAccess.Repository.IRepository
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(string name);
        User AddUser(User user);
        void DeleteUser(User user);
        User EditUser(User user);
    }
}
