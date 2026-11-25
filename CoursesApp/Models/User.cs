using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApp.Models
{
    public enum UserRole { Student, Teacher }
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }   
        public string FullName { get; set; }
        public UserRole Role { get; set; }
    }
}
