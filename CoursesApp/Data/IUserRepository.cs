using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApp.Data
{
    public interface IUserRepository
    {
        User? Authenticate(string login, string password);
        bool LoginExists(string login);
        void Add(User user);
        IEnumerable<User> GetAll();
    }
}
