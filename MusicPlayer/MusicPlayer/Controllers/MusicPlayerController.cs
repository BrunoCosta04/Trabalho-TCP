using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Extensions;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;
using NAudio.Midi;

namespace MusicPlayer.Controllers
{
    public class MusicPlayerController : Controller
    {
        public IndexViewModel componentsValues { get; set; }
        public IActionResult Index()
        {
            /*Colocar o volume também na inicialização*/
            if (componentsValues == null)
            {
                componentsValues = new IndexViewModel()
                {
                    Music = new Music(),
                    DropdownListInstruments = InstrumentData.Instruments.ReturnSelectListFromData(x => x.Name, x => x.Id.ToString()),
                    DropdownListOctaves = OctaveData.Octaves.ReturnSelectListFromData(x => x.Name, x => x.Id.ToString())
                };
            }

            return View("Index", componentsValues);
        }
        [HttpPost]
        public IActionResult PlaySong(Music music, int instrument, int octave, int volume)
        {
            MusicPlayerTest musicPlayerTest = new MusicPlayerTest();
            musicPlayerTest.PlayTeste("TESTE");

            return Content("OK");
        }

        [HttpGet]
        public IActionResult DownloadMIDI(Music music, string outputPath)
        {
            MidiFile.Export(outputPath, music.MusicText);

            return View("Index");
        }
    }
}