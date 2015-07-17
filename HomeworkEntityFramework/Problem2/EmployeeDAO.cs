using System.Data.Entity;
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
                Employee empl = context.Employees.Find(employee.EmployeeID);

                if (empl != null)
                {
                    empl = employee;
                }

                context.Entry(empl).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static void Delete(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
    }
}
