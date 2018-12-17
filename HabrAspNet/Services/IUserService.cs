using HabrAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Services
{
    public interface IUserService
    {
        User GetUser(int id);
        User AddUser(User user);
        List<User> GetUsers();
        bool CheckEmail(string email);
        bool CheckLogin(string login);
    }
}
