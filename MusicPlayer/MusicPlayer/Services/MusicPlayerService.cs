using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    internal static class MusicPlayerService
    {
        public static void Play(MidiEventCollection midiEventsCollection)
        {
            MessageBox.Show("Espere até a música acabar! Clique para continuar.");

            using (var midiOut = new MidiOut(0))
            {
                var midiEvents = midiEventsCollection[0];

                foreach (var midiEvent in midiEvents)
                {
                    midiOut.Send(midiEvent.GetAsShortMessage());

                    if (midiEvent.CommandCode == MidiCommandCode.NoteOn)
                    {
                        Thread.Sleep((midiEvent as NoteOnEvent).NoteLength * 4);
                        //Thread.Sleep(differenceBetweenAbsoluteTimes);
                    }
                }
            }
        }
    }
}
