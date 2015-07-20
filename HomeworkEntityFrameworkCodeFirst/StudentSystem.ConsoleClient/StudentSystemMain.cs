using System;
using System.Linq;
using StudentSystem.Data;

namespace StudentSystem.ConsoleClient
{
    public class StudentSystemMain
    {
        static void Main(string[] args)
        {
            using (var context = new StudentSystemModel())
            {
                /* 1. Lists all students and their homework submissions.
                      Select only their names and for each homework - content and content-type. */

                var students = from student in context.Students
                    select new
                    {
                        Name = student.Name,
                        Homeworks = from homework in student.Homeworks
                                    select new
                                    {
                                        Content = homework.Content,
                                        ContentType = homework.ContentType
                                    }
                    };

                /* 2. List all courses with their corresponding resources. Select the course name and description and everything for each resource.
                      Order the courses by start date (ascending), then by end date (descending). */

                var allCourses = from course in context.Courses
                    orderby course.StartDate ascending, course.EndDate descending
                    select new
                    {
                        CourseName = course.Name,
                        Description = course.Description,
                        Resources = course.Resources
                    };

                /* 3. List all courses with more than 5 resources.
                      Order them by resources count (descending), then by start date (descending). 
                      Select only the course name and the resource count. */

                var coursesWithMoreThan5Resources = from course in context.Courses
                    where course.Resources.Count > 5
                    orderby course.Resources.Count descending, course.StartDate descending
                    select new
                    {
                        CourseName = course.Name,
                        ResourcesCount = course.Resources.Count
                    };

                /* 4. List all courses which were active on a given date (choose the date depending on the data seeded to ensure there are results),
                    and for each course count the number of students enrolled. 
                    Select the course name, start and end date, course duration (difference between end and start date) and number of students enrolled.
                    Order the results by the number of students enrolled (in descending order), then by duration (descending). */
                
                var theChoosenDate = new DateTime(2014, 1, 15);
                var coursesOnAGivenData = from course in context.Courses
                    where theChoosenDate >= course.StartDate && theChoosenDate <= course.EndDate
                    orderby course.Students.Count descending, (course.EndDate - course.StartDate).TotalDays descending
                    select new
                    {
                        CourseName = course.Name,
                        StartDate = course.StartDate,
                        EndDate = course.EndDate,
                        Duration = (course.EndDate - course.StartDate).TotalDays,
                        NumberOfStudentsEnrolled = course.Students.Count
                    };

                /* 5. For each student, calculate the number of courses he/she has enrolled in,
                      the total price of these courses and the average price per course for the student.
                      Select the student name, number of courses, total price and average price. 
                      Order the results by total price (descending),
                      then by number of courses (descending) and then by the student's name (ascending). */

                var studentCourseEnrolls = from student in context.Students
                    orderby student.Courses.Sum(c => c.Price) descending,
                        student.Courses.Count descending, student.Name ascending
                    select new
                    {
                        Name = student.Name,
                        NumberOfCourse = student.Courses.Count,
                        TotalPrice = student.Courses.Sum(c => c.Price),
                        AveragePrice = student.Courses.Average(c => c.Price)
                    };
            }
        }
    }
}
