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
            new InstrumentEntity(){ Id = 0,  Name = "Acoustic Grand Piano"},
            new InstrumentEntity(){ Id = 3,  Name = "Honky-tonk Piano"},
            new InstrumentEntity(){ Id = 6,  Name = "Harpsichord"},
            new InstrumentEntity(){ Id = 9,  Name = "Glockenspiel"},
            new InstrumentEntity(){ Id = 12,  Name = "Marimba"},
            new InstrumentEntity(){ Id = 15,  Name = "Dulcimer"},
            new InstrumentEntity(){ Id = 18,  Name = "Rock Organ"},
            new InstrumentEntity(){ Id = 21,  Name = "Accordion"},
            new InstrumentEntity(){ Id = 24,  Name = "Acoustic Guitar (nylon)"},
            new InstrumentEntity(){ Id = 27,  Name = "Electric Guitar (clean)"},
            new InstrumentEntity(){ Id = 30,  Name = "Distortion Guitar"},
            new InstrumentEntity(){ Id = 33,  Name = "Electric Bass (finger)"},
            new InstrumentEntity(){ Id = 36,  Name = "Slap Bass 1"},
            new InstrumentEntity(){ Id = 39,  Name = "Synth Bass 2"},
            new InstrumentEntity(){ Id = 42,  Name = "Cello"},
            new InstrumentEntity(){ Id = 45,  Name = "Pizzicato Strings"},
            new InstrumentEntity(){ Id = 48,  Name = "String Ensemble 1"},
            new InstrumentEntity(){ Id = 51, Name = "Synth Strings 2"},
            new InstrumentEntity(){ Id = 54, Name = "Synth Voice"},
            new InstrumentEntity(){ Id = 57,  Name = "Trombone"},
            new InstrumentEntity(){ Id = 60,  Name = "French Horn"},
            new InstrumentEntity(){ Id = 63,  Name = "Synth Brass 2"},
            new InstrumentEntity(){ Id = 66,  Name = "Tenor Sax"},
            new InstrumentEntity(){ Id = 69,  Name = "English Horn"},
            new InstrumentEntity(){ Id = 72,  Name = "Piccolo"},
            new InstrumentEntity(){ Id = 75,  Name = "Pan Flute"},
            new InstrumentEntity(){ Id = 78,  Name = "Whistle"},
            new InstrumentEntity(){ Id = 81,  Name = "Lead 2 (sawtooth)"},
            new InstrumentEntity(){ Id = 84,  Name = "Lead 5 (charang)"},
            new InstrumentEntity(){ Id = 87,  Name = "Lead 8 (brass + lead)"},
            new InstrumentEntity(){ Id = 90,  Name = "Pad 3 (polysynth)"},
            new InstrumentEntity(){ Id = 93,  Name = "Pad 6 (metallic)"},
            new InstrumentEntity(){ Id = 96,  Name = "FX 1 (rain)"},
            new InstrumentEntity(){ Id = 99, Name = "FX 4 (atmosphere)"},
            new InstrumentEntity(){ Id = 102, Name = "FX 7 (echoes)"},
            new InstrumentEntity(){ Id = 105,  Name = "Banjo"},
            new InstrumentEntity(){ Id = 108,  Name = "Kalimba"},
            new InstrumentEntity(){ Id = 111,  Name = "Shana"},
            new InstrumentEntity(){ Id = 114,  Name = "Steel Drums"},
            new InstrumentEntity(){ Id = 117,  Name = "Melodic Tom"},
            new InstrumentEntity(){ Id = 120,  Name = "Guitar Fret Noise"},
            new InstrumentEntity(){ Id = 123,  Name = "Bird Tweet"},
        };

        public static IEnumerable<OctaveEntity> Octaves = new List<OctaveEntity>()
        {
            new OctaveEntity(){ Id = 1, Name = "First"},
            new OctaveEntity(){ Id = 2, Name = "Second"},
            new OctaveEntity(){ Id = 3, Name = "Third"},
            new OctaveEntity(){ Id = 4, Name = "Fourth"},
            new OctaveEntity(){ Id = 5, Name = "Fifth"},
            new OctaveEntity(){ Id = 6, Name = "Sixth"},
            new OctaveEntity(){ Id = 7, Name = "Seventh"},
            new OctaveEntity(){ Id = 8, Name = "Eighth"},
        };
    }
}
