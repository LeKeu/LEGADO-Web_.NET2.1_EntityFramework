using Microsoft.AspNetCore.Mvc;
using Sales_Web_MVC.Models;
using Sales_Web_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public SellersController(SellerService sellerService)
        {
            _sellerservice = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerservice.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerservice.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
