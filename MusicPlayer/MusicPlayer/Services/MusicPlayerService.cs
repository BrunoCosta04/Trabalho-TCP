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
            using (var midiOut = new MidiOut(0))
            {
                var midiEvents = midiEventsCollection[0];
                long differenceBetweenAbsoluteTimes = 0;

                foreach (var midiEvent in midiEvents)
                {
                    midiOut.Send(midiEvent.GetAsShortMessage());

                    if (midiEvent.CommandCode == MidiCommandCode.NoteOn)
                    {
                        differenceBetweenAbsoluteTimes = midiEvent.AbsoluteTime - differenceBetweenAbsoluteTimes;
                        //Thread.Sleep((midiEvent as NoteOnEvent).NoteLength);
                        //Thread.Sleep(differenceBetweenAbsoluteTimes);
                    }
                }
            }
        }
    }
}
