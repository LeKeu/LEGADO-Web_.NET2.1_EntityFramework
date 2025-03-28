using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Sales_Web_MVC.Models.ViewModels;

namespace Sales_Web_MVC.Controllers
{
    public class HomeController : Controller // como que coloquei "HomeController", o caminho vai ser Home!
    {
        // e como é fortemente orientado a nomes, o "Index" é uma "ação".
        // então se, no endereço, eu digitar Home/Index, vai para a página de index
        public IActionResult Index()
        {
            return View();
        }

        // mesma coisa com o about e o resto
        public IActionResult About()
        {
            ViewData["Message"] = "Sales Web MVC App do curso que to fazendo!";
            ViewData["Aluna"] = "Filoretti";
            // adicionei um valor no meu dicionário, agora posso acessá-lo poelo cshtml dele

            // aqui eu vou estar "criando" (é um method builder). retorna um IActionResult
            // ele vê que eu to instanciando uma view na ação about, e o framework procura na pasta do Home o About!
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
