using ELearningPlatform.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearningPlatform.Data
{
    class ELearningPlatformContext : DbContext
    {
        //Entities IN DATABASE
        public DbSet<User> Users {get;set;}
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserCourses> UserCoursess { get; set; }
        public DbSet<Courses> Coursess { get; set; }
        public DbSet<Questions> Questionss { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=ELearning;Integrated Security=SSPI;");
        }
    }
}
