﻿using EmployeeManagement.Models;
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

        public IActionResult Details(int id)
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                Employee = _iemployeeRepository.GetEmployee(id),
                PageTitle = "Employee details",
            };
            return View(model);
        }
    }
}
