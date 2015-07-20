using System;
using System.Linq;
using Problem1;

namespace Problem3
{
    class SearchQueriesMain
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniEntities())
            {
                /*1. 1. Find all employees who have projects started in the time period 2001 - 2003 (inclusive). Select each employee's first name,
                     last name and manager name and each of their projects' name, start date, end date.*/

                var employees = from employee in context.Employees
                                join manager in context.Employees on employee.ManagerID equals manager.EmployeeID
                    where employee.Projects.Any(p => p.StartDate.Year >= 2001
                                                     && p.EndDate.Value.Year <= 2003)
                    select new
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        ManagerName = manager.FirstName + " " + manager.MiddleName + "" + manager.LastName,
                        Projects = from project in employee.Projects
                                   where project.StartDate.Year >= 2001 
                                   && project.EndDate.Value.Year <= 2003
                                   select new
                                   {
                                       Name = project.Name,
                                       StartDate = project.StartDate,
                                       EndDate = project.EndDate
                                   }
                    };
                    

                /*2. Find all addresses, ordered by the number of employees who live there (descending),
                     then by town name (ascending). Take only the first 10 addresses and select their address text,
                     town name and employee count. */

                var addresses = (from address in context.Addresses
                                orderby address.Employees.Count descending,
                                address.Town.Name ascending 
                                select new
                                {
                                    AddressText = address.AddressText,
                                    TownName = address.Town.Name,
                                    EmployeeCount = address.Employees.Count
                                }).Take(10);

                foreach (var address in addresses)
                {
                    Console.WriteLine("{0}, {1} - {2} employees",
                        address.AddressText,
                        address.TownName,
                        address.EmployeeCount);
                }

                /*3. Get an employee by id (e.g. 147). Select only his/her first name, last name, job title and projects (only their names).
                     The projects should be ordered by name (ascending). */

                var employeeById = (from employee in context.Employees
                                   where employee.EmployeeID == 147
                                   select new
                                   {
                                        FirstName = employee.FirstName,
                                        LastName = employee.LastName,
                                        JobTitle = employee.JobTitle,
                                        Projects = from project in employee.Projects
                                                   orderby project.Name
                                                   select project.Name
                                   }).FirstOrDefault();

                /*4. Find all departments with more than 5 employees. Order them by employee count (ascending). 
                     Select the department name, manager name and first name, last name,
                     hire date and job title of every employee. */

                var deparments = from department in context.Departments
                                 where department.Employees.Count > 0
                                 orderby department.Employees.Count ascending 
                                 select new
                                 {
                                     DepartmentName = department.Name,
                                     ManagerName = context.Employees.Where(e => e.EmployeeID == department.ManagerID).FirstOrDefault().FirstName,
                                     Employees = from employee in department.Employees
                                                 select new
                                                 {
                                                     FirstName = employee.FirstName,
                                                     LastName = employee.LastName,
                                                     HireDate = employee.HireDate,
                                                     JobTitle = employee.JobTitle
                                                 }
                                 };

                Console.WriteLine(deparments.Count());

                foreach (var deparment in deparments)
                {
                    Console.WriteLine("--{0} - Manager: {1}, Employees: {2}",
                        deparment.DepartmentName,
                        deparment.ManagerName,
                        deparment.Employees.Count());
                }
            }
        }
    }
}
