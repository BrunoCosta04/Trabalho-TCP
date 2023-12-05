using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;

namespace MusicPlayer.Controllers
{
    public class MusicPlayerController : Controller
    {
        public IActionResult Index()
        {
            //popular comboboxes

            //IndexViewModel indexViewModel = new IndexViewModel();

            //indexViewModel.instruments = new List<Instrument>()
            //{
            //    new Instrument(){ Id=0,Name="Piano"},
            //    new Instrument(){ Id=27,Name="Eletric Guitar"},
            //};

            List<string> list = new List<string>();
            list.Add("teste");

            ViewBag.Test = new SelectList(list);

            return View();
        }

        [HttpPost]
        public IActionResult Teste([FromForm] Music music)
        {



            //retornar os parametros escolhidos no momento do clique


            return View(music);
        }
    }
}