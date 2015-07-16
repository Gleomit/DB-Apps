using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem1;

namespace Problem3
{
    class SearchQueriesMain
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniEntities())
            {
                /*1. Find all employees who have projects started in the time period 2001 - 2003 (inclusive).
                     Select the project's name, start date, end date and manager name.*/

                var employees = from employee in context.Employees
                    select employee;

                /*2. Find all addresses, ordered by the number of employees who live there (descending),
                     then by town name (ascending). Take only the first 10 addresses and select their address text,
                     town name and employee count. */

                var addresses = from address in context.Addresses
                                select address;

                /*3. Get an employee by id (e.g. 147). Select only his/her first name, last name, job title and projects (only their names).
                     The projects should be ordered by name (ascending). */

                var employeeById = from employee in context.Employees
                                   select employee;

                /*4. Find all departments with more than 5 employees. Order them by employee count (ascending). 
                     Select the department name, manager name and first name, last name,
                     hire date and job title of every employee. */

                var deparments = from department in context.Departments
                                 select department;
            }
        }
    }
}
