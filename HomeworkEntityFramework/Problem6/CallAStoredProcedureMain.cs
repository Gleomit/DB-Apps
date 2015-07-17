using System;

namespace Problem6
{
    class CallAStoredProcedureMain
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniEntities())
            {
                var projects = context.GetProjectsByEmployee("Ruth", "Ellerbrock");

                foreach (var project in projects)
                {
                    Console.WriteLine("{0} - {1}, {2}", 
                        project.Name,
                        (project.Description.Length > 29 ? project.Description.Substring(0, 30) + "..." : project.Description), 
                        project.StartDate);
                }
            }
        }
    }
}
