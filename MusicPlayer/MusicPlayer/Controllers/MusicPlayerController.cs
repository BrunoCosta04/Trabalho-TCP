using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Extensions;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;

namespace MusicPlayer.Controllers
{
    public class MusicPlayerController : Controller
    {
        public IActionResult Index()
        {
            IndexViewModel componentsValues = new IndexViewModel();

            componentsValues.Music = new Music();
            componentsValues.DropdownListInstruments = InstrumentData.Instruments.ReturnSelectListFromData(x => x.Name, x => x.Id.ToString());
            componentsValues.DropdownListOctaves = OctaveData.Octaves.ReturnSelectListFromData(x => x.Name, x => x.Id.ToString());

            return View(componentsValues);
        }

        //[HttpPost]
        public IActionResult Teste(Music music, int instrument, int octave, int volume)
        {



            //retornar os parametros escolhidos no momento do clique


            return View();
        }
    }
}