using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private List<Employee> employee_list;
        public EmployeeRepository()
        {
            employee_list = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Ali", Email="Ali@gmail.com", Department=Dept.IT},
                new Employee() { Id = 2, Name = "Ahmed", Email="Ahmed@gmail.com", Department=Dept.Marketing},
                new Employee() { Id = 3, Name = "Mohamed", Email="Mohamed@gmail.com", Department=Dept.Sales},
                new Employee() { Id = 4, Name = "Mostafa", Email="Mostafa@gmail.com", Department=Dept.RD}
            };
        }
        public Employee GetEmployee(int id)
        {
            return employee_list.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetAll()
        {
            return employee_list;
        }

        public Employee Add(Employee employee)
        {
            employee.Id =  employee_list.Max(e => e.Id) + 1;
            employee_list.Add(employee);
            return employee;
        }
    }
}
