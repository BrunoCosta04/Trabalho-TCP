using MusicPlayer.Models.Interface;
using NAudio.Midi;
using static System.Net.Mime.MediaTypeNames;

namespace MusicPlayer.Models
{
    public class MusicPlayerTest //: IMusicPlayer
    {
        public MidiOut MidiOut { get; private set; }
        public Music Music { get; private set; }
        public int Volume { get; private set; }
        public int VolumeDefault { get; private set; }
        public int InstrumentActual { get; private set; }
        public int ChannelDefault { get; private set; }
        public bool IsPlaying { get; private set; }
        public bool IsPaused { get; private set; }

        public MusicPlayerTest(MidiOut midiOut, Music music, int volumeDefault, int instrument)
        {
            ChannelDefault = 1;
            MidiOut = midiOut;
            Music = music;
            VolumeDefault = volumeDefault;
            Volume = volumeDefault;
            InstrumentActual = instrument;
            MidiOut = new MidiOut(1);
        }
        public MusicPlayerTest() { }

        public MidiEventCollection PlayTeste(string text)
        {
            MidiEventCollection midiEvents = new MidiEventCollection(0, 480);

            //logica para popular 
            MusicGenerator.AddEventsFromText(midiEvents, 60);
            MusicGenerator.AddEventsFromText(midiEvents, 65);
            MusicGenerator.AddEventsFromText(midiEvents, 70);
            MusicGenerator.AddEventsFromText(midiEvents, 75);

            MidiOut midiOut = new MidiOut(0);
            foreach (var midiEvent in midiEvents[0])
            {
                midiOut.Send(midiEvent.GetAsShortMessage());
            }

            return midiEvents;
        }

        //public void ChangeVolume(int newVolume)
        //{
        //    int minimalVolume = 0;
        //    int maximalVolume = 100;

        //    //if (newVolume >= minimalVolume && newVolume <= maximalVolume)
        //    //    _volume = newVolume;
        //}

        //public void ChangeInstrument(int newInstrument)
        //{
        //    //_midiOut.Send(MidiMessage.ChangePatch(newInstrument, defaultChannel).RawData);
        //}

        //public void PlayNote(int note)
        //{
        //    MidiOut.Send(MidiMessage.StartNote(note, VolumeDefault, ChannelDefault).RawData);
        //}

        //public void Silence()
        //{
        //    Thread.Sleep(1000);
        //}

        //public void Play()
        //{
        //    //fazer o loop e o switch case
        //}
        public void ChangeVolume()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
