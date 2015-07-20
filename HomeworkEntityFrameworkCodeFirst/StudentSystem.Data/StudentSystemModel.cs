using StudentSystem.Data.Migrations;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystemModel : DbContext
    {
        // Your context has been configured to use a 'StudentSystemModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StudentSystem.Data.StudentSystemModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentSystemModel' 
        // connection string in the application configuration file.
        public StudentSystemModel()
            : base("name=StudentSystemModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemModel, Configuration>());
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; } 
    }
}