using Microsoft.AspNetCore.Mvc;
using Sales_Web_MVC.Models;
using Sales_Web_MVC.Models.ViewModels;
using Sales_Web_MVC.Services;
using System.Collections.Generic;
using Sales_Web_MVC.Services.Exceptions;
using System.Diagnostics;
using System;

namespace Sales_Web_MVC.Controllers
{
    public class SellersController : Controller
    {
        /*
        Criando o controller do zero
        criei esse controller igual ao nome da minha classe Sellers
        na pasta de views, crio uma pasta com o exato mesmo nome Sellers
        na pasta Sellers, crio uma view vazia chamada index

        No site, quando eu clico na area de sellers, controlador é acionado
        como não foi especificada uma ação, é a index que será acionada
        a index só retorna a chamada view, que retorna um iactionresult considerando esse nome de view (o index)
        ele vai acionar a view que estiver na pastinha sellers e que tenha o nome index
        */

        private readonly SellerService _sellerservice;
        private readonly DepartmentService _departmentservice;

        public SellersController(SellerService sellerService, DepartmentService departmentservice)
        {
            _sellerservice = sellerService;
            _departmentservice = departmentservice;
        }

        public IActionResult Index()
        {
            var list = _sellerservice.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentservice.FindAll();
            var viewModel = new SellerFromViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerservice.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = _sellerservice.FindById(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Object not found" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerservice.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = _sellerservice.FindById(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = _sellerservice.FindById(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            List<Department> departments = _departmentservice.FindAll();
            SellerFromViewModel viewModel = new SellerFromViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });

            try
            {
                _sellerservice.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
