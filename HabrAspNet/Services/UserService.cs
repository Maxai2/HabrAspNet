using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabrAspNet.Models;

namespace HabrAspNet.Services
{
    public class UserService : IUserService
    {
        private HabrContext context;

        public UserService(HabrContext context)
        {
            this.context = context;
        }

        public User AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public bool CheckEmail(string email)
        {
            return context.Users.Where(u => u.Email == email).Count() > 0;
        }

        public bool CheckLogin(string login)
        {
            return context.Users.Where(u => u.Login == login).Count() > 0;
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }
    }
}
