using NAudio.Gui;
using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    internal class MusicGeneratorService
    {
        //aqui ta a continuacao do codigo de exemplo GUI
        public static void AddEventsFromText(MidiEventCollection midiEvents, int noteNumber, int volume, ref long tempo)
        {




            //foreach (char character in text)
            //{

            int velocity = volume; // Set a default velocity

            // Add note-on and note-off events to the collection
            AddNoteOnEvent(midiEvents, tempo, noteNumber, velocity);
            tempo += 50000;
            AddNoteOffEvent(midiEvents, tempo, noteNumber, velocity);
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

        public static void ChangeInstrument(int instrument)
        {
            using (MidiOut midiOut = new MidiOut(0))
            {
                // Envie a mensagem de mudança de instrumento
                midiOut.Send(MidiMessage.ChangePatch(instrument, 1).RawData);
            }
        }
        static void AdjustBPM(MidiEventCollection midiEvents, int newBPM)
        {
            // Converter BPM para microssegundos por batida
            int microSecondsPerBeat = (int)(60000000.0 / newBPM);

            // Percorrer os eventos da sequência
            foreach (var track in midiEvents)
            {
                foreach (var midiEvent in track)
                {
                    // Verificar se é um evento de mudança de tempo
                    if (midiEvent is TempoEvent tempoEvent)
                    {
                        // Ajustar o valor do tempo
                        tempoEvent.MicrosecondsPerQuarterNote = microSecondsPerBeat;
                    }
                }
            }
        }

        /* public static void UpdateBPM(MidiEventCollection midiEvents, int newBPM)
         {
             int microSecondsPerQuarterNote = (int)(60000000.0 / newBPM);




                 if (midiEvents.CommandCode == MidiCommandCode.MetaEvent)
                 {
                     var metaEvent = midiEvents as MetaEvent;

                     if (metaEvent.MetaEventType == MetaEventType.SetTempo)
                     {
                         var setTempoEvent = metaEvent as TempoEvent;
                         setTempoEvent.MicrosecondsPerQuarterNote = microSecondsPerQuarterNote;
                     }
                 }
             }*/






    }
}
