using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoins
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>
            {
                new Employee{Id = 1,Name = "Mark", DepartmentId = 1},
                new Employee{Id = 2, Name = "Steve",DepartmentId = 2},
                new Employee{ Id = 3, Name = "Benn",DepartmentId = 1},
                new Employee{ Id = 4, Name = "Vikas",DepartmentId = 2},
                new Employee{ Id = 5, Name = "Bhawana",DepartmentId = 1},
                new Employee{ Id = 6, Name = "Manish",DepartmentId = 3},
                new Employee{ Id = 7, Name = "Rahul",DepartmentId = 3},
                new Employee{ Id = 8, Name = "Abishek",DepartmentId = 2},
                new Employee{ Id = 9, Name = "Rakesh",DepartmentId = 3},
                new Employee{ Id = 10, Name = "Harsh",DepartmentId = 4}
            };
        }
    }
}
