using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Extensions;
using MusicPlayer.Models;
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using NAudio.Midi;
using System.Diagnostics;

namespace MusicPlayer.Controllers
{
    public class MusicPlayerController : Controller
    {
        public IndexViewModel componentsValues { get; set; } = new IndexViewModel()
        {
            Music = new Music(),
            DropdownListInstruments = InstrumentData.Instruments.ReturnSelectListFromData(x => x.Name, x => x.Id.ToString()),
            DropdownListOctaves = OctaveData.Octaves.ReturnSelectListFromData(x => x.Name, x => x.Id.ToString())
        };
        public IActionResult Index()
        {
            var fileInput = TempData["NewMusicText"] as string;
            var newMusic = TempData["MusicGenerate"] as MidiEventCollection;


            if (!string.IsNullOrEmpty(fileInput))
                componentsValues.Music.Text = fileInput;

            if (newMusic != null)
                componentsValues.Music.MusicText = newMusic;

            return View("Index", componentsValues);
        }

        [HttpPost]
        public IActionResult GenerateMusic()
        {

            TempData["MusicGenerate"] = new MidiEventCollection(0, 480);


            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PlaySong(Music music, int instrument, int octave, int volume)
        {
            MusicPlayerService musicPlayerTest = new MusicPlayerService();
            componentsValues.Music.MusicText = musicPlayerTest.PlayTeste("TESTE");




            return Content("OK");
        }

        [HttpGet]
        public IActionResult Download(Music music)
        {
            string outputPath = "";

            MidiFile.Export(outputPath, music.MusicText);

            return View("Index");
        }

        [HttpPost]
        public IActionResult Upload(IndexViewModel model)
        {
            if (model.FileInput != null && model.FileInput.Length > 0)
            {
                string content = string.Empty;

                using (var resource = new StreamReader(model.FileInput.OpenReadStream()))
                {
                    content = resource.ReadToEnd();
                }

                TempData["NewMusicText"] = content;
            }

            return RedirectToAction("Index");
        }
    }
}