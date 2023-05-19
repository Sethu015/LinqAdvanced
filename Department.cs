using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoins
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Department> GetAllDepartments()
        {
            return new List<Department>
            {
                new Department{Id = 1,Name = "HR"},
                new Department{Id = 2, Name = "Technical"},
                new Department{ Id = 3, Name = "Finance"},
                new Department{ Id=5,Name = "Support"}
            };
        }
    }
}
