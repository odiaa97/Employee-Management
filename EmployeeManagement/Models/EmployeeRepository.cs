using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private IEnumerable<Employee> employee_list;
        public EmployeeRepository()
        {
            employee_list = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Ali", Email="Ali@gmail.com", Department="IT"},
                new Employee() { Id = 2, Name = "Ahmed", Email="Ahmed@gmail.com", Department="Marketing"},
                new Employee() { Id = 3, Name = "Mohamed", Email="Mohamed@gmail.com", Department="Dales"},
                new Employee() { Id = 4, Name = "Mostafa", Email="Mostafa@gmail.com", Department="R&D"},
            };
        }
        public Employee GetEmployee(int id)
        {
            return employee_list.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employee_list;
        }
    }
}
