using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales_Web_MVC.Models;

namespace Sales_Web_MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> listDepartamentos = new List<Department>();

            listDepartamentos.Add(new Department { Id = 1, Name = "Eletronicos" }) ;
            listDepartamentos.Add(new Department { Id = 2, Name = "Fashion" });

            return View(listDepartamentos);
        }
    }
}
