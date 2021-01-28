using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _iemp;
        public HomeController(IEmployeeRepository emp)
        {
            _iemp = emp;
        }
        public IActionResult Index()
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                Employees = _iemp.GetAll(),
                PageTitle = "Employees Home Page",
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                Employee = _iemp.GetEmployee(id),
                PageTitle = "Employee details",
            };
            return View(model);
        }
    }
}
