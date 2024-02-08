using MusicPlayer.Extensions;
using MusicPlayer.Models;
using MusicPlayer.Services;
using NAudio.CoreAudioApi;
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
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\song.mid";

                FileService.Download(Music.Song, desktopPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTocarMusica_Click(object sender, EventArgs e)
        {
            try
            {
                //bool isAbleToPlay = InputValidationService.MusicValidation(Music.Song);

                //if (isAbleToPlay)
                //{
                this.Teste();

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AppendEndMarker(IList<MidiEvent> eventList)
        {
            long absoluteTime = 0;
            if (eventList.Count > 0)
                absoluteTime = eventList[eventList.Count - 1].AbsoluteTime;
            eventList.Add(new MetaEvent(MetaEventType.EndTrack, 0, absoluteTime));
        }

        private void btnGenerateMusic_Click(object sender, EventArgs e)
        {
            try
            {
                string music = txtMusic.Text;
                var selectedIntrument = Convert.ToInt32(cmbInstruments.SelectedValue);
                var selectedOctave = Convert.ToInt32(cmbOctaves.SelectedValue);

                bool isAbleToGenerateMusic = InputValidationService.UserInputValidation(music, selectedIntrument, selectedOctave);

                if (isAbleToGenerateMusic)
                {









                    //this.Music.ChangeMusic();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion Events

        #region Methods
        private void LoadMusic()
        {
            this.Music = new Music();
        }
        private void LoadComboxInstruments()
        {
            cmbInstruments.DisplayMember = "Text";
            cmbInstruments.ValueMember = "Value";

            var data = DataBase.Instruments;

            cmbInstruments.DataSource = data.BindComboBox(x => x.Name, x => x.Id, true);
        }
        private void LoadComboxOctaves()
        {
            cmbOctaves.DisplayMember = "Text";
            cmbOctaves.ValueMember = "Value";

            var data = DataBase.Octaves;

            cmbOctaves.DataSource = data.BindComboBox(x => x.Name, x => x.Id, true);
        }

        private void Teste()
        {
            int absoluteTime = 1;
            int channel = 1;
            int noteNumber = 54;
            int volume = 127;
            int duration = 1;

            MidiEventCollection midiEventCollection = new MidiEventCollection(1, 120);
            midiEventCollection.AddTrack();

            MidiEvent changeInstrument = new PatchChangeEvent(0, channel, 0);
            NoteOnEvent noteOn = new NoteOnEvent(absoluteTime, channel, noteNumber, volume, duration);
            NoteEvent noteOff = new NoteEvent(absoluteTime + duration, channel, MidiCommandCode.NoteOff, noteNumber, 0);

            var midiEvents = midiEventCollection[0];

            midiEvents.Add(changeInstrument);
            midiEvents.Add(noteOn);
            midiEvents.Add(noteOff);

            //esperar um tempo

            absoluteTime = absoluteTime + 2000;
            duration = 3000;
            noteNumber = 54;

            changeInstrument = new PatchChangeEvent(absoluteTime, channel, 27);
            absoluteTime += 1;
            noteOn = new NoteOnEvent(absoluteTime, channel, noteNumber, volume, duration);
            noteOff = new NoteEvent(absoluteTime + duration, channel, MidiCommandCode.NoteOff, noteNumber, 0);

            midiEvents.Add(changeInstrument);
            midiEvents.Add(noteOn);
            midiEvents.Add(noteOff);

            AppendEndMarker(midiEvents);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\song.mid";
            MidiFile.Export(desktopPath, midiEventCollection);

            //MusicPlayerService.Play(midiEventCollection);

            
        }
        private string ToMBT(long eventTime, int ticksPerQuarterNote, TimeSignatureEvent timeSignature)
        {
            int beatsPerBar = timeSignature == null ? 4 : timeSignature.Numerator;
            int ticksPerBar = timeSignature == null ? 
                                    ticksPerQuarterNote * 4 
                                    : (timeSignature.Numerator * ticksPerQuarterNote * 4) / (1 << timeSignature.Denominator);
            int ticksPerBeat = ticksPerBar / beatsPerBar;
            long bar = 1 + (eventTime / ticksPerBar);
            long beat = 1 + ((eventTime % ticksPerBar) / ticksPerBeat);
            long tick = eventTime % ticksPerBeat;
            return string.Format("{0}:{1}:{2}", bar, beat, tick);
        }
        #endregion Methods
    }
}
