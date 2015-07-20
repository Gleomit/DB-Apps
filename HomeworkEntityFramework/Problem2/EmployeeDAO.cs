using System.Data.Entity;
using System.Linq;
using Problem1;

namespace Problem2
{
    public static class EmployeeDAO
    {
        public static void Add(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }     
        }

        public static Employee FindByKey(object key)
        {
            using (var context = new SoftUniEntities())
            {
                return context.Employees.Find((int)key);
            }
        }

        public static void Modify(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                Employee empl = context.Employees.SingleOrDefault(e => e.EmployeeID == employee.EmployeeID);

                if (empl != null)
                {
                    empl.FirstName = employee.FirstName;
                    empl.LastName = employee.LastName;
                    empl.MiddleName = employee.MiddleName;
                    empl.AddressID = employee.AddressID;
                    empl.ManagerID = employee.ManagerID;
                    empl.DepartmentID = employee.DepartmentID;
                    empl.JobTitle = employee.JobTitle;
                    empl.Salary = employee.Salary;
                    empl.HireDate = employee.HireDate;
                }

                context.SaveChanges();
            }
        }

        public static void Delete(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                Employee empl = context.Employees.Find(employee.EmployeeID);
                context.Employees.Remove(empl);
                context.SaveChanges();
            }
        }

        public static Employee LastEmployee()
        {
            using (var context = new SoftUniEntities())
            {
                return context.Employees.OrderByDescending(e => e.EmployeeID).First();
            } 
        }
    }
}
