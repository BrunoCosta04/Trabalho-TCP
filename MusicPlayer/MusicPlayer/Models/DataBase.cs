using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    internal static class DataBase
    {
        public static IEnumerable<InstrumentEntity> Instruments = new List<InstrumentEntity>()
        {
            new InstrumentEntity(){ Id = 0, Name = "Piano"},
            new InstrumentEntity(){ Id = 27, Name = "Eletric Guitar"},
        };

        public static IEnumerable<OctaveEntity> Octaves = new List<OctaveEntity>()
        {
            new OctaveEntity(){ Id = 1, Name = "First"},
            new OctaveEntity(){ Id = 2, Name = "Second"},
        };
    }
}
