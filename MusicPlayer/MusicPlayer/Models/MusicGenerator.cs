using NAudio.Midi;

namespace MusicPlayer.Models
{
    public static class MusicGenerator
    {
        public static void AddEventsFromText(MidiEventCollection midiEvents, int noteNumber)
        {
            long currentTime = 0;

            //foreach (char character in text)
            //{

            int velocity = 80; // Set a default velocity

            // Add note-on and note-off events to the collection
            AddNoteOnEvent(midiEvents, currentTime, noteNumber, velocity);
            //currentTime += 500; // Adjust the duration between notes (in milliseconds)
            AddNoteOffEvent(midiEvents, currentTime, noteNumber, velocity);
            //}
        }

        public static void AddNoteOnEvent(MidiEventCollection midiEvents, long absoluteTime, int noteNumber, int velocity)
        {
            midiEvents.AddEvent(new NoteOnEvent(absoluteTime, 1, noteNumber, velocity, 500), 0);
        }

        public static void AddNoteOffEvent(MidiEventCollection midiEvents, long absoluteTime, int noteNumber, int velocity)
        {
            midiEvents.AddEvent(new NoteEvent(absoluteTime, 1, MidiCommandCode.NoteOff, noteNumber, velocity), 0);
        }
    }
}
