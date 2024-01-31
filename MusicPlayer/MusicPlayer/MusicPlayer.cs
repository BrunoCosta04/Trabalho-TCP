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
                MidiEventCollection midiEvents = new MidiEventCollection(0, 480);
                string path = "setar diretorio dos downloads";
                //generate music

                FileService.Download(Music.Song, path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTocarMusica_Click(object sender, EventArgs e)
        {
            //Aplication Flow:
            //Verificar se todas as entradas do usuário são válidas.
            //Retornar exception se erro.
            //Gerar musica.
            //Retornar exeption se erro.
            //Habilitar o botão de Play.
            //Daí o resto é na lógica do Play.



















            // ATENÇÃO GUI, AQUI TA O CODIGO DE EXEMPLO P GERAR OS SONS DO ULTIMO CODIGO

            MidiEventCollection midiEvents = new MidiEventCollection(0, 480);

            //logica para popular 
            MusicGeneratorService.AddEventsFromText(midiEvents, 50);
            MusicGeneratorService.AddEventsFromText(midiEvents, 65);
            MusicGeneratorService.AddEventsFromText(midiEvents, 70);
            MusicGeneratorService.AddEventsFromText(midiEvents, 75);

            MidiOut midiOut = new MidiOut(0);
            foreach (var midiEvent in midiEvents[0])
            {
                midiOut.Send(midiEvent.GetAsShortMessage());
            }
            midiOut.Close();


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
            {//-------------------- Parte do validation que tem que refazer ou pegar do duds se ele achar.
                int selectedInstrumentIndex = cmbInstruments.SelectedIndex;
                int selectedOctaveIndex = cmbOctaves.SelectedIndex;
                string Music = txtMusic.Text; // Esta string é uma variável local somente usada para verificar se o campo não é vazio.

                InputValidationService.UserInputValidation(Music, selectedInstrumentIndex, selectedOctaveIndex);
                //------------------------------------------------------------------------------------------




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
        #endregion Methods

        //Por agora estes eventos não possuem função específica.
        private void cmbInstruments_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string selectedInstrumentIndex = cmbInstruments.SelectedIndex.ToString();
            //MessageBox.Show($"Opção selecionada: {selectedInstrumentIndex}");
        }

        private void cmbOctaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedOctaveIndex = cmbOctaves.SelectedIndex.ToString();
            //MessageBox.Show($"Opção selecionada: {selectedOctaveIndex}");
        }

        private void txtMusic_TextChanged(object sender, EventArgs e)
        {
            //string Music = txtMusic.Text;
            //MessageBox.Show(Music);
        }
    }
}
