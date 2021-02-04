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
        private readonly IEmployeeRepository _iemployeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _iemployeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                Employees = _iemployeeRepository.GetAll(),
                PageTitle = "Employees Home Page",
            };
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                Employee = _iemployeeRepository.GetEmployee(id??1),
                PageTitle = "Employee details",
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                Employee newEmployee = _iemployeeRepository.Add(employee);
                return RedirectToAction("details", new { id = employee.Id });
            }
            return View();
        }
    }
}
