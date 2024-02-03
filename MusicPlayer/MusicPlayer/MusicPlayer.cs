using MusicPlayer.Extensions;
using MusicPlayer.Models;
using MusicPlayer.Services;
using NAudio.Midi;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MusicPlayer
{
    public partial class MusicPlayer : Form
    {
        private Music Music { get; set; }

        #region Initialization
        public MusicPlayer()
        {
            InitializeComponent();
        }

        private void MusicPlayer_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadComboxInstruments();
                this.LoadComboxOctaves();
                this.LoadMusic();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion Initialization

        #region Events
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string newMusic = string.Empty;

                newMusic = FileService.Upload();

                txtMusic.Text = newMusic;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();

                FileService.Download(Music.Song, path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTocarMusica_Click(object sender, EventArgs e)
        {
            this.TocarMusica3();

            //MidiEventCollection midiEvents = new MidiEventCollection(0, 480);

            //MusicGeneratorService.AddEventsFromText(midiEvents, 60);
            //MusicGeneratorService.AddEventsFromText(midiEvents, 65);
            //MusicGeneratorService.AddEventsFromText(midiEvents, 70);
            //MusicGeneratorService.AddEventsFromText(midiEvents, 75);

            //MidiOut midiOut = new MidiOut(0);
            //foreach (var midiEvent in midiEvents[0])
            //{
            //    midiOut.Send(midiEvent.GetAsShortMessage());
            //}
            //midiOut.Close();


            //try
            //{
            //    string music = txtMusic.Text;
            //    int octaveValue = Convert.ToInt32(cmbOctaves.SelectedValue);
            //    int instrumentValue = Convert.ToInt32(cmbInstruments.SelectedValue);
            //    int volume = tbVolume.Value;

            //    bool isAbleToPlay = InputValidationService.UserInputValidation(txtMusic.Text, octaveValue, instrumentValue);

            //    if (isAbleToPlay)
            //    {
            //        //generate music

            //        //play Music
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void btnGenerateMusic_Click(object sender, EventArgs e)
        {
            try
            {
                MidiEventCollection midiEvents = new MidiEventCollection(0, 480);

                NoteEvent noteOn = new NoteOnEvent(2000, 1, 60, 127, 0);
                NoteEvent noteOff = new NoteEvent(2000, 1, MidiCommandCode.NoteOff, 60, 0);

                midiEvents.AddEvent(noteOn, 0);
                midiEvents.AddEvent(noteOff, 0);

                noteOn = new NoteOnEvent(1000, 1, 45, 127, 0);
                noteOff = new NoteEvent(1000, 1, MidiCommandCode.NoteOff, 45, 0);

                midiEvents.AddEvent(noteOn, 0);
                midiEvents.AddEvent(noteOff, 0);

                this.Music.ChangeMusic(midiEvents);






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion Events

        #region Methods
        private void LoadComboxInstruments()
        {
            cmbInstruments.DisplayMember = "Text";
            cmbInstruments.ValueMember = "Value";

            var data = DataBase.Instruments;

            cmbInstruments.DataSource = data.BindComboBox(x => x.Name, x => x.Id, true);
            //MessageBox.Show(cmbInstruments.);
        }

        private void LoadComboxOctaves()
        {
            cmbOctaves.DisplayMember = "Text";
            cmbOctaves.ValueMember = "Value";

            var data = DataBase.Octaves;

            cmbOctaves.DataSource = data.BindComboBox(x => x.Name, x => x.Id, true);
        }

        private void LoadMusic()
        {
            this.Music = new Music();
        }
        private void TocarMusica2()
        {
            int numberDevice = 0;
            int channel = 1;
            int noteNumber = 50;


            using (var midiOut = new MidiOut(numberDevice))
            {
                var noteOnEvent = new NoteOnEvent(0, channel, noteNumber, 100, 50);
                midiOut.Send(noteOnEvent.GetAsShortMessage());
            }

            //TempoEvent tempoEvent = new TempoEvent();





            string instrumento;

        }

        private void TocarMusica1()
        {
            //MidiEventCollection midiEvents = new MidiEventCollection(0, 1000);

            //NoteEvent noteEvent = new NoteOnEvent(0, 1, 60, 127, 5000);
            //midiEvents.AddEvent(noteEvent, 0);
            //noteEvent = new NoteOnEvent(1000, 1, 45, 127, 10);
            //midiEvents.AddEvent(noteEvent, 0);

            //MidiOut midiOut = new MidiOut(0);


            //var teste2 = midiEvents[0][0];

            //midiOut.Send(midiEvents[0][0].GetAsShortMessage());
            //midiOut.Send(midiEvents[0][1].GetAsShortMessage());

            //TempoEvent tempoEvent = new TempoEvent();
        }

        private void TocarMusica3()
        {
            var song = this.Music.Song;

            using (var midiOut = new MidiOut(0))
            {
                var note = song[0][0];

                midiOut.Send(note.GetAsShortMessage());
                Thread.Sleep((int)note.AbsoluteTime);
                note = song[0][1];
                midiOut.Send(note.GetAsShortMessage());

                note = song[0][2];
                midiOut.Send(note.GetAsShortMessage());
                Thread.Sleep((int)note.AbsoluteTime);
                note = song[0][3];
                midiOut.Send(note.GetAsShortMessage());
            }

            string path = "C:\\Users\\Marcus\\Desktop\\teste.mid";
            FileService.Download(song, path);


            using (var midiOut = new MidiOut(0))
            {
                MidiFile midiFile = new MidiFile(path);

                foreach (var teste in midiFile.Events[0])
                {
                    midiOut.Send(teste.GetAsShortMessage());




                    Thread.Sleep((int)teste.AbsoluteTime);
                }
            }








        }
        #endregion Methods
    }
}
