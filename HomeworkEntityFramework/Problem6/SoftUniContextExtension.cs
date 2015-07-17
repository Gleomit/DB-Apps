using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.SqlServer.Server;
using Problem1;

namespace Problem6
{
    public partial class SoftUniEntities : DbContext
    {
        public ICollection<Project> GetProjectsByEmployee(string firstName, string lastName)
        {
            return this.Database.SqlQuery<Project>("EXEC GetProjectsByEmployee @FirstName, @LastName",
                new SqlParameter("@FirstName", firstName), new SqlParameter("@LastName", lastName)).ToList<Project>();
        }
    }
}
