using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
