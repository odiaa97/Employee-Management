﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployee(int id);
        public IEnumerable<Employee> GetAll();

        public Employee Add(Employee employee);
        public Employee Update(Employee employee);

        public Employee Delete(int id);


    }
}
