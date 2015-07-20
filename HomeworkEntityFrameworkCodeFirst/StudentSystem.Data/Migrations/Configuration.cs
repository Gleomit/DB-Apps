using System.Linq;

namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using StudentSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemModel context)
        {
            if (!context.Students.Any())
            {
                context.Students.AddOrUpdate(new Student
                {
                    Name = "Student1",
                    PhoneNumer = "359 000 000",
                    Birthday = new DateTime(1950, 1, 1),
                    RegistrationDate = new DateTime(2015, 1, 1)
                });

                context.Students.AddOrUpdate(new Student
                {
                    Name = "Student2",
                    PhoneNumer = "359 111 000",
                    Birthday = new DateTime(1952, 1, 1),
                    RegistrationDate = new DateTime(2015, 1, 1)
                });

                context.Students.AddOrUpdate(new Student
                {
                    Name = "Student3",
                    PhoneNumer = "359 222 000",
                    Birthday = new DateTime(1954, 1, 1),
                    RegistrationDate = new DateTime(2015, 1, 2)
                });

                context.Students.AddOrUpdate(new Student
                {
                    Name = "Student4",
                    PhoneNumer = "359 222 000",
                    Birthday = new DateTime(1956, 1, 1),
                    RegistrationDate = new DateTime(2015, 1, 3)
                });

                var course = new Course
                {
                    Name = "Course 1",
                    Description = "jgds gldsldjf dgj dgf g ",
                    StartDate = new DateTime(2014, 1, 1),
                    EndDate = new DateTime(2014, 1, 30),
                    Price = 100
                };

                context.Courses.AddOrUpdate(course);

                context.SaveChanges();

                var theCourse = context.Courses.Find(1);

                var resource1 = new Resource
                {
                    Name = "Resource 1",
                    ResourceType = ResourceType.Video,
                    Url = "www.youtube.com",
                    CourseId = theCourse.Id
                };

                context.Resources.AddOrUpdate(resource1);

                var resource2 = new Resource
                {
                    Name = "Resource 2",
                    ResourceType = ResourceType.Document,
                    Url = "www.google.com",
                    CourseId = theCourse.Id
                };

                context.Resources.AddOrUpdate(resource2);

                theCourse.Resources.Add(resource1);
                theCourse.Resources.Add(resource2);
                context.Courses.AddOrUpdate(theCourse);

                course = new Course
                {
                    Name = "Course 2",
                    Description = "jgds gldsldjf dgj dgf g ",
                    StartDate = new DateTime(2015, 2, 1),
                    EndDate = new DateTime(2015, 2, 25),
                    Price = 200
                };

                context.Courses.AddOrUpdate(course);

                context.SaveChanges();

                var student = context.Students.Find(1);
                var course1 = context.Courses.Find(1);

                context.Homeworks.AddOrUpdate(new Homework
                {
                    Content = "Homework 1",
                    CourseId = course1.Id,
                    StudentId = student.Id,
                    SubmissionDate = new DateTime(2015, 3, 30, 23, 59, 59),
                    ContentType = ApplicationType.zip
                });

                context.SaveChanges();
            }
        }
    }
}
