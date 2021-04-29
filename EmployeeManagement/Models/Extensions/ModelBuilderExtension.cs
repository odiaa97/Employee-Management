using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee 
                { 
                    Id = 1, Name = "Omar Diaa",
                    Email = "Omardiaa27@gmail.com",
                    department = Dept.IT 
                }
            );
        }
    }
}
