using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;

namespace MusicPlayer.Controllers
{
    public class MusicPlayer : Controller
    {
        public IActionResult Index()
        {
            //popular comboboxes



            return View();
        }

        [HttpPost]
        public IActionResult Teste()
        {
            //retornar os parametros escolhidos no momento do clique


            return View("Index");
        }
    }
}