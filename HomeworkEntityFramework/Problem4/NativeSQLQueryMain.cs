using System;
using System.Diagnostics;
using System.Linq;
using Problem1;

namespace Problem4
{
    public class NativeSQLQueryMain
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniEntities())
            {
                var totalCount = context.Employees.Count();

                var sw = new Stopwatch();
                sw.Start();
                PrintNamesWithNativeQuery();

                Console.WriteLine("Native: {0}", sw.Elapsed);

                sw.Restart();

                PrintNamesWithLinqQuery();
                Console.WriteLine("Linq: {0}", sw.Elapsed);
            }
        }

        static void PrintNamesWithNativeQuery()
        {
            using (var context = new SoftUniEntities())
            {
                var employeesFirstNames = context.Database.SqlQuery<string>("SELECT e.FirstName FROM EmployeesProjects AS ep" +
                                                                            " INNER JOIN Employees AS e ON e.EmployeeID = ep.EmployeeID" +
                                                                            " INNER JOIN Projects AS p ON p.ProjectID = ep.ProjectID" +
                                                                            " WHERE YEAR(p.StartDate) = 2002");

                foreach (var employee in employeesFirstNames)
                {
                    Console.WriteLine(employee);
                }
            }
        }

        static void PrintNamesWithLinqQuery()
        {
            using (var context = new SoftUniEntities())
            {
                var employeesFirstNames = from employee in context.Employees
                    where employee.Projects.Any(p => p.StartDate.Year == 2002)
                    select employee.FirstName;

                foreach (var employee in employeesFirstNames)
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }
}
