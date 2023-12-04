using NAudio.Midi;
using System.Threading.Channels;

namespace MusicPlayer.Models
{
    public class MusicPlayer
    {
        private Music _music { get; set; }

        public MusicPlayer(Music music)
        {
            _music = music;
        }

        public void ChangeStatus(bool isPlaying, bool isPaused, bool isStopped)
        {
            _music.IsPlaying = isPlaying;
            _music.IsPaused = isPaused;
            _music.IsStopped = isStopped;
        }
        public void ChangeVolume(int newVolume)
        {
            int minimalVolume = 0;
            int maximalVolume = 100;

            if (newVolume >= minimalVolume && newVolume <= maximalVolume)
                _music.Volume = newVolume;
        }
        public void Stop()
        {
            ChangeStatus(false, false, true);
        }
        public void Pause()
        {
            ChangeStatus(false, true, false);
        }
        public void Play()
        {
            ChangeStatus(true, false, false);

            while (!_music.IsStopped)
            {
                if (_music.IsPlaying)
                {
                    //tocar musica!
                }
            }

            int note = 60; // dó médio
            int volume = 127;
            int channel = 1;

            using (MidiOut midiOut = new MidiOut(0))
            {
                //piano
                CustomPlay(midiOut, note, _music.Volume, channel, _music.Instrument);
                Thread.Sleep(1000);

                //eletric guitar
                CustomPlay(midiOut, note, volume, channel, 27);
                Thread.Sleep(1000);
            }

        }
        private void CustomPlay(MidiOut midiOut, int note, int volume, int channel, int instrument)
        {
            midiOut.Send(MidiMessage.ChangePatch(instrument, channel).RawData);
            midiOut.Send(MidiMessage.StartNote(note, volume, channel).RawData);
        }
    }
}
