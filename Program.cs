using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoins
{
    class Program
    {
        public static void Main(string[] args)
        {
            //1
            //Group Join --> Produces hireachial data structures(Same as outer join in sql).
            //Each element from the first collection has set of correlated elements from second collection
            var employeesByDepartment = Department.GetAllDepartments()
                .GroupJoin(Employee.GetAllEmployees(), d => d.Id, e => e.DepartmentId,
                (department, employee) => new
                {
                    Department = department,
                    Employee = employee
                });
            foreach (var department in employeesByDepartment)
            {
                Console.WriteLine(department.Department.Name);
                Console.WriteLine();
                //2
                //Linq ForEach
                department.Employee.ToList().ForEach(
                    emp => Console.WriteLine(emp.Name));
                Console.WriteLine("---------------------------------");
            }

            //3
            //Inner Join --> Same as Inner join in Sql Matching elements are included in result set
            //Not matching set is not included in result set

            var employeesAndDepartment = Employee.GetAllEmployees().Join(
                Department.GetAllDepartments(), e => e.DepartmentId, d => d.Id,
                (employee, department) => new
                {
                    Employee = employee,
                    Department = department
                });
            foreach (var result in employeesAndDepartment)
            {
                Console.WriteLine(result.Employee.Name + " " + result.Department.Name);
            }

            //4
            //SelectMany --> Flattens the n number of Enumerable object into single object
            //Left Outer Join

            var departmentAndEmployees = Employee.GetAllEmployees().GroupJoin(
                Department.GetAllDepartments(), e => e.DepartmentId, d => d.Id,
                (emp, depts) => new
                {
                    Employee = emp,
                    Departments = depts
                })
                //If collection is empty it will load default and it flattens IEnumerable<Department>
                .SelectMany(z => z.Departments.DefaultIfEmpty(),
                (a, b) => new
                {
                    EmployeeName = a.Employee.Name,
                    DepartmentName = b == null ? "No Name" : b.Name
                });

            foreach (var item in departmentAndEmployees)
            {
                Console.WriteLine(item.EmployeeName + "  " + item.DepartmentName);
            }

            //5
            //Cross Join --> If 3 results in Table A and 2 results in Table 2 it will produce 3*2 = 6 Results
            var employeeDepartmentCrossJoin = Department.GetAllDepartments().Join(
                Employee.GetAllEmployees(),
                d => true,
                e => true,
                (d, e) => new
                {
                    Department = d,
                    Employee = e
                });
            employeeDepartmentCrossJoin.ToList().ForEach(
                obj =>
                {
                    Console.WriteLine(obj.Employee.Name + "  " + obj.Department.Name);
                }
                );

            //6
            //Union
            var l1 = new List<int> { 1, 2, 3, 4, 5 };
            var l2 = new List<int> { 2 , 3, 6, 7, 8 };
            foreach (var item in l1.Union(l2))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //7
            //Intersect
            foreach (var item in l1.Intersect(l2))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            //8
            //Except --> Minus
            foreach (var item in l2.Except(l1))
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }
    }
}
