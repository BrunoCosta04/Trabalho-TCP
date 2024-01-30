using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public sealed class Music
    {
        public Music() { }
        public MidiEventCollection Song { get; private set; }
        public void ChangeMusic(MidiEventCollection midiEvents)
        {
            Song = midiEvents;
        }
    }
}
