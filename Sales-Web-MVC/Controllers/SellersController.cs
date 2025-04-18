﻿using Microsoft.AspNetCore.Mvc;
using Sales_Web_MVC.Models;
using Sales_Web_MVC.Models.ViewModels;
using Sales_Web_MVC.Services;
using System.Collections.Generic;
using Sales_Web_MVC.Services.Exceptions;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var list = await _sellerservice.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentservice.FindAllAsync();
            var viewModel = new SellerFromViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentservice.FindAllAsync();
                var viewModel = new SellerFromViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            await _sellerservice.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = await _sellerservice.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Object not found" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerservice.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = await _sellerservice.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = await _sellerservice.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            List<Department> departments = await _departmentservice.FindAllAsync();
            SellerFromViewModel viewModel = new SellerFromViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentservice.FindAllAsync();
                var viewModel = new SellerFromViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if (id != seller.Id)
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });

            try
            {
                await _sellerservice.UpdateAsync(seller);
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
