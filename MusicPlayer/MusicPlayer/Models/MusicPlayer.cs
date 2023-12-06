using NAudio.Midi;
using System.Threading.Channels;

namespace MusicPlayer.Models
{
    public class MusicPlayer
    {
        private Music _music { get; set; }
        private int _volume { get; set; }
        private MidiOut _midiOut { get; set; }
        public int _instrument { get; set; }
        public int _octave { get; set; }
        private int defaultChannel = 1;

        public MusicPlayer(Music music, MidiOut midiOut, int volume, int instrument, int octave)
        {
            _music = music;
            _volume = volume;
            _midiOut = midiOut;
            _instrument = instrument;
            _octave = octave;
        }

        public void ChangeVolume(int newVolume)
        {
            int minimalVolume = 0;
            int maximalVolume = 100;

            if (newVolume >= minimalVolume && newVolume <= maximalVolume)
                _volume = newVolume;
        }

        public void ChangeInstrument(int newInstrument)
        {
            _midiOut.Send(MidiMessage.ChangePatch(newInstrument, defaultChannel).RawData);
        }

        public void PlayNote()
        {
            //_midiOut.Send(MidiMessage.StartNote(note, volume, defaultChannel).RawData);
        }

        public void Silence()
        {
            Thread.Sleep(1000);
        }

        public void Play()
        {
            //fazer o loop e o switch case
        }
    }
}
