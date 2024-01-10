using NAudio.Midi;

namespace MusicPlayer.Models
{
    public class MIDIFile
    {
        public void Download(MidiEventCollection midiEvents, string outputPath)
        {
            MidiFile.Export(outputPath, midiEvents);
        }
    }
}
