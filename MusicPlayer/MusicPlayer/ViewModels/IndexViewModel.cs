using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPlayer.Models;

namespace MusicPlayer.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<SelectListItem> DropdownListInstruments { get; set; }
        public IEnumerable<SelectListItem> DropdownListOctaves { get; set; }

    }
}
