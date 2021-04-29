using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _iemployeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnvironment)
        {
            _iemployeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
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
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath + @"\images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    department = model.department,
                    PhotoPath = uniqueFileName
                };
                _iemployeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
