using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEFdemo.Models;
namespace CodeFirstEFdemo.Data
{
    class AppDbContext:DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Students> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-H1K2MNG\\SQLEXPRESS;Database=CGDb1;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "John Doe" },
                new Author { Id = 2, Name = "Jane Smith" }
            );

            // Seed Courses (with AuthorId)
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "C# Basics", Description = "Intro to C#", level = CourseLevel.Beginner, AuthorId = 1 },
                new Course { Id = 2, Title = "Advanced .NET", Description = "Deep dive into .NET", level = CourseLevel.Intermediate, AuthorId = 1 },
                new Course { Id = 3, Title = "Azure Fundamentals", Description = "Cloud basics", level = CourseLevel.Beginner, AuthorId = 2 }
            );

            // Seed Students
            modelBuilder.Entity<Students>().HasData(
                new Students { Id = 1, Name = "Alice Johnson" },
                new Students { Id = 2, Name = "Bob Wilson" },
                new Students { Id = 3, Name = "Carol Davis" }
            );

            //// Seed Many-to-Many join table
            //modelBuilder.Entity<CourseStudent>().HasData(
            //    new StudentCourse { StudentId = 1, CourseId = 1 },  // Alice in C# Basics
            //    new StudentCourse { StudentId = 1, CourseId = 2 },  // Alice in Advanced .NET
            //    new StudentCourse { StudentId = 2, CourseId = 1 },  // Bob in C# Basics
            //    new StudentCourse { StudentId = 2, CourseId = 3 },  // Bob in Azure
            //    new StudentCourse { StudentId = 3, CourseId = 2 }   // Carol in Advanced .NET
            //);
        }
    }
}

    