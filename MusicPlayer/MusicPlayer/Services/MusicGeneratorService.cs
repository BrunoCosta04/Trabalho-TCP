using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    internal class MusicGeneratorService
    {
        public static MidiEventCollection GenerateMusic(string music, int defaultVolume, ref int octave, int instrument)
        {
            music = music.ToUpper();

            int musicSize = music.Length;
            int newVolume = defaultVolume;
            int duration = 200;
            int defaultChannel = 1;

            var midiEventsCollection = new MidiEventCollection(0, 120);
            midiEventsCollection.AddTrack();
            AddChangeInstrumentEvent(midiEventsCollection, 1, 1, instrument);

            for (int i = 0; i < musicSize; i++)
            {
                Command_Check(midiEventsCollection, music, i, ref octave, ref newVolume, defaultVolume, ref duration, defaultChannel);
            }

            AppendEndMarker(midiEventsCollection);

            return midiEventsCollection;
        }

        private static long GetLastAbsoluteTime(MidiEventCollection midiEvents)
        {
            var eventList = midiEvents[0];
            var absoluteTime = eventList.Count <= 0 ? 0 : eventList[eventList.Count - 1].AbsoluteTime;

            return absoluteTime;
        }
        private static void Command_Check(MidiEventCollection midiEvents, string music, int i, ref int octaveValue, ref int volume, int volumeDefault, ref int duration, int channel)
        {
            var absoluteTime = GetLastAbsoluteTime(midiEvents);
            int defaultChannel = 1;

            int changeNoteByOctave = 12;
            int noteNumber;
            int finalNote;

            Random random = new Random();

            char caracter = music[i];
            switch (caracter)
            {
                case 'A':

                    noteNumber = 9;
                    finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                    AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);

                    break;
                case 'B':

                    noteNumber = 11;
                    finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                    if (music.Length - (i + 3) >= 0)
                    {
                        if (music[i + 1] == 'P' && music[i + 2] == 'M' && music[i + 3] == '+')
                        {

                            i = i + 3;
                            if (duration > 200)

                                duration -= 571; //AUMENTA O BPM EM 80 PONTOS

                            if (duration < 200)

                                duration = 200;
                        }
                        else
                        {
                            AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
                            break;
                        }
                        break;
                    }
                    AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
                    break;
                case 'C':
                    noteNumber = 0;
                    finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                    AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
                    break;
                case 'D':
                    noteNumber = 2;
                    finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                    AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
                    break;
                case 'E':
                    noteNumber = 4;
                    finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                    AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
                    break;
                case 'F':
                    noteNumber = 5;
                    finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                    AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
                    break;
                case 'G':
                    noteNumber = 7;
                    finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                    AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
                    break;

                case ' ':

                    noteNumber = 0;
                    finalNote = 0;

                    AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, 0, duration);
                    break;
                case '+':
                    if (volume * 2 > 127)
                    {
                        volume = 127;
                    }
                    else
                    {
                        volume *= 2;
                    }
                    break;
                case '-':
                    volume = volumeDefault;
                    break;
                case '\n':
                    int newInstrument = 60; //french horn
                    AddChangeInstrumentEvent(midiEvents, absoluteTime, channel, newInstrument);
                    break;
                case ';':

                    duration = random.Next(200, 1200);
                    break;

                case 'R':
                    if (music[i + 1] == '+')
                    {
                        octaveValue++;
                        i++;
                        if (octaveValue > 8)
                            octaveValue = 0;
                    }
                    else if (music[i + 1] == '-')
                    {
                        i++;
                        octaveValue--;
                        if (octaveValue < 0)
                            octaveValue = 8;
                    }
                    break;

                case '?':
                    int[] meuVetor = { 0, 2, 4, 5, 7, 9, 11 };
                    int indiceAleatorio = random.Next(0, meuVetor.Length);
                    int numeroAleatorio = meuVetor[indiceAleatorio];

                    noteNumber = numeroAleatorio;
                    finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                    if (numeroAleatorio > 0)
                        AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);

                    else
                        AddNoteEvents(midiEvents, absoluteTime, defaultChannel, octaveValue * 1, volume, duration);
                    break;

                case 'O':
                    AddNoteOnVowel(midiEvents, music, i, octaveValue, changeNoteByOctave, absoluteTime, defaultChannel, volume, duration);
                    break;
                case 'U':
                    AddNoteOnVowel(midiEvents, music, i, octaveValue, changeNoteByOctave, absoluteTime, defaultChannel, volume, duration);
                    break;
                case 'I':
                    AddNoteOnVowel(midiEvents, music, i, octaveValue, changeNoteByOctave, absoluteTime, defaultChannel, volume, duration);
                    break;
            }
        }
        private static void AddNoteEvents(MidiEventCollection midiEvents, long absoluteTime, int channel, int noteNumber, int volume, int duration)
        {
            AddNoteOnEvent(midiEvents, absoluteTime, channel, noteNumber, volume, duration);
            AddNoteOffEvent(midiEvents, absoluteTime + duration, channel, noteNumber, volume);
        }
        private static void AddNoteOnEvent(MidiEventCollection midiEvents, long absoluteTime, int channel, int noteNumber, int volume, int duration)
        {
            midiEvents.AddEvent(new NoteOnEvent(absoluteTime, channel, noteNumber, volume, duration), 0);
        }
        private static void AddNoteOffEvent(MidiEventCollection midiEvents, long absoluteTime, int channel, int noteNumber, int volume)
        {
            midiEvents.AddEvent(new NoteEvent(absoluteTime, channel, MidiCommandCode.NoteOff, noteNumber, volume), 0);
        }
        private static void AddChangeInstrumentEvent(MidiEventCollection midiEvents, long absoluteTime, int channel, int instrumentNumber)
        {
            midiEvents.AddEvent(new PatchChangeEvent(absoluteTime, channel, instrumentNumber), 0);
        }
        private static void AppendEndMarker(MidiEventCollection midiEvents)
        {
            long absoluteTime = GetLastAbsoluteTime(midiEvents);
            midiEvents[0].Add(new MetaEvent(MetaEventType.EndTrack, 0, absoluteTime));
        }
        private static void AddNoteOnVowel(MidiEventCollection midiEvents, string music, int i, int octaveValue,
                                            int changeNoteByOctave, long absoluteTime, int defaultChannel, int volume, int duration)
        {
            int noteNumber;
            int finalNote;

            if (music[i - 1] == 'A')
            {
                noteNumber = 9;
                finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
            }
            else if (music[i - 1] == 'B')
            {
                noteNumber = 5;
                finalNote = noteNumber + (octaveValue * changeNoteByOctave);
                AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
            }
            else if (music[i - 1] == 'C')
            {
                noteNumber = 0;
                finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
            }
            else if (music[i - 1] == 'D')
            {
                noteNumber = 2;
                finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
            }
            else if (music[i - 1] == 'E')
            {
                noteNumber = 4;
                finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
            }
            else if (music[i - 1] == 'F')
            {
                noteNumber = 5;
                finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
            }
            else if (music[i - 1] == 'G')
            {
                noteNumber = 7;
                finalNote = noteNumber + (octaveValue * changeNoteByOctave);

                AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
            }
            else
            {
                finalNote = 125; //telefone tocando
                AddNoteEvents(midiEvents, absoluteTime, defaultChannel, finalNote, volume, duration);
            }


        }
    }
}
