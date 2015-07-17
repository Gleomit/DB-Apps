using StudentSystem.Data;

namespace StudentSystem.ConsoleClient
{
    public class StudentSystemMain
    {
        static void Main(string[] args)
        {
            using (var context = new StudentSystemModel())
            {
                context.Homeworks.Find(0);
            }
        }
    }
}
