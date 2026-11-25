using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace CoursesApp.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public InMemoryUserRepository()
        {
            Add(new User { Login = "student", Password = "123", FullName = "Иванов Иван", Role = UserRole.Student });
            Add(new User { Login = "teacher", Password = "123", FullName = "Петров Пётр", Role = UserRole.Teacher });
        }

        public User? Authenticate(string login, string password) =>
            _users.FirstOrDefault(u => u.Login == login && u.Password == password);

        public bool LoginExists(string login) => _users.Any(u => u.Login == login);

        public void Add(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public IEnumerable<User> GetAll() => _users;
    }
}
