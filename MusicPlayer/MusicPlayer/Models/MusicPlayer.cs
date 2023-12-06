using NAudio.Midi;

namespace MusicPlayer.Models
{
    public class MusicPlayer
    {
        public MidiOut MidiOut { get; private set; }
        public Music Music { get; private set; }
        public int Volume { get; private set; }
        public int VolumeDefault { get; private set; }
        public int InstrumentActual { get; private set; }
        public int ChannelDefault { get; private set; }
        public bool IsPlaying { get; private set; }
        public bool IsPaused { get; private set; }

        public MusicPlayer(MidiOut midiOut, Music music, int volumeDefault, int instrument )
        {
            ChannelDefault = 1;
            MidiOut = midiOut;
            Music = music;
            VolumeDefault = volumeDefault;
            Volume = volumeDefault;
            InstrumentActual = instrument;

        }

        public void ChangeVolume(int newVolume)
        {
            int minimalVolume = 0;
            int maximalVolume = 100;

            //if (newVolume >= minimalVolume && newVolume <= maximalVolume)
            //    _volume = newVolume;
        }

        public void ChangeInstrument(int newInstrument)
        {
            //_midiOut.Send(MidiMessage.ChangePatch(newInstrument, defaultChannel).RawData);
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
