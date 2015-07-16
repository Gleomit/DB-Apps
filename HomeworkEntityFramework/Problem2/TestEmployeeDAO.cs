using System;
using Problem1;

namespace Problem2
{
    public class TestEmployeeDAO
    {
        public static void Main()
        {
            var employee = EmployeeDAO.FindByKey(297);

            Console.WriteLine(employee.ToString());

            EmployeeDAO.Delete(employee);

            Console.Read();
        }
    }
}
