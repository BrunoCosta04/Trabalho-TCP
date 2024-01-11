using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPlayer.Models;

namespace MusicPlayer.ViewModels
{
    public class IndexViewModel
    {
        public Music Music { get; set; }
        public IEnumerable<SelectListItem> DropdownListInstruments { get; set; }
        public IEnumerable<SelectListItem> DropdownListOctaves { get; set; }
        public IFormFile FileInput { get; set; }
        public int Volume { get; set; }
    }
}
