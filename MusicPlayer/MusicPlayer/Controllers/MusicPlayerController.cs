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

            componentsValues.DropdownListInstruments = InstrumentData.Instruments.PopulateSelectList(x => x.Name, x => x.Id.ToString());
            componentsValues.DropdownListOctaves = OctaveData.Octaves.PopulateSelectList(x => x.Name, x => x.Id.ToString());

            return View(componentsValues);
        }

        [HttpPost]
        public IActionResult Teste([FromForm] Music music)
        {



            //retornar os parametros escolhidos no momento do clique


            return View(music);
        }
    }
}