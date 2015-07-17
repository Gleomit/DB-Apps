using System.Data.Entity;
using Problem1;

namespace Problem5
{
    class ConcurentDatabaseChangesMain
    {
        static void Main(string[] args)
        {
            var contextOne = new SoftUniEntities();
            var contextTwo = new SoftUniEntities();

            var tempEmployeeOne = contextOne.Employees.Find(147);
            var tempEmployeeTwo = contextTwo.Employees.Find(147);

            tempEmployeeOne.MiddleName = tempEmployeeOne.MiddleName + "Changed From Context One";
            tempEmployeeTwo.MiddleName = tempEmployeeTwo.MiddleName + "Changed From Context Two";

            contextOne.Entry(tempEmployeeOne).State = EntityState.Modified;
            contextTwo.Entry(tempEmployeeTwo).State = EntityState.Modified;

            contextOne.SaveChanges();
            contextTwo.SaveChanges();
        }
    }
}
