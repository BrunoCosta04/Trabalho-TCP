using NAudio.Midi;

namespace MusicPlayer.Models
{
    public class Music
    {
        public string Text { get; set; } = string.Empty;
        public MidiEventCollection MusicText { get; set; }
    }
}
