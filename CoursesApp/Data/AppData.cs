using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApp.Data
{
    public static class AppData
    {
        public static IUserRepository Users { get; } = new InMemoryUserRepository();

        public static List<Course> Courses { get; } = new()
        {
            new Course { Id = 1, Title = "Основы C#",          Description = "Введение в язык",       TeacherName = "Петров Пётр" },
            new Course { Id = 2, Title = "WPF для начинающих", Description = "XAML, MVVM, навигация", TeacherName = "Петров Пётр" },
            new Course { Id = 3, Title = "Базы данных",        Description = "SQL, EF Core",          TeacherName = "Сидоров Сидор" },
        };
    }
}
