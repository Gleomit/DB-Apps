namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using StudentSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemModel context)
        {
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                context.Students.AddOrUpdate(new Student()
                {
                    Name = "Student" + i,
                    RegistrationDate = DateTime.Now,
                    PhoneNumer = "0891324564"
                });

            }

            context.SaveChanges();

            for (int i = 0; i < 3; i++)
            {
                context.Courses.AddOrUpdate(new Course()
                {
                    Name = "Course" + i,
                    Description = "Decription For Course" + i,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Price = Decimal.Parse(random.Next(150, 250).ToString())
                });
            }

            context.SaveChanges();

            for (int i = 0; i < 3; i++)
            {
                context.Resources.AddOrUpdate(new Resource()
                {
                    Name = "Resource" + i,
                    ResourceType = ResourceType.Document,
                    Url = "url.com",
                    CourseId = random.Next(1, 3)
                });
            }

            context.SaveChanges();

            for (int i = 0; i < 3; i++)
            {
                context.Homeworks.AddOrUpdate(new Homework()
                {
                    Content = "Content" + i,
                    ContentType = ApplicationType.pdf,
                    SubmissionDate = DateTime.Now,
                    CourseId = random.Next(1, 3)
                });
            }

            context.SaveChanges();
        }
    }
}
