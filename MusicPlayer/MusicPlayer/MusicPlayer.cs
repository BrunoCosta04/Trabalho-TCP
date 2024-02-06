using MusicPlayer.Extensions;
using MusicPlayer.Models;
using MusicPlayer.Services;
using NAudio.Midi;
using System;
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
                //MidiEventCollection midiEvents = new MidiEventCollection(0, 480);
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

            //MidiEventCollection midiEvents = new MidiEventCollection(0, 480);

            // logica para popular
            /* MusicGeneratorService.AddEventsFromText(midiEvents, 50,100);
             MusicGeneratorService.AddEventsFromText(midiEvents, 65,100);
             MusicGeneratorService.AddEventsFromText(midiEvents, 70,100);
             MusicGeneratorService.AddEventsFromText(midiEvents, 75,100);
           
            MessageBox.Show(txtMusic.Text.ToUpper());
            MidiOut midiOut = new MidiOut(0);
            foreach (var midiEvent in midiEvents[0])
            {

                midiOut.Send(midiEvent.GetAsShortMessage());
            }
            midiOut.Close();
            */


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
            {   //-------------------- Parte do validation que tem que refazer ou pegar do duds se ele achar.
                int selectedInstrumentIndex = cmbInstruments.SelectedIndex;
                int selectedOctaveIndex = cmbOctaves.SelectedIndex;
                string Music = txtMusic.Text; // Esta string é uma variável local somente usada para verificar se o campo não é vazio.

                InputValidationService.UserInputValidation(Music, selectedInstrumentIndex, selectedOctaveIndex);




                //------------------------------------------------------------------------------------------
                string music = txtMusic.Text.ToUpper(); //transformo em maiuscula para facilitar o switch case
                int octaveValue = Convert.ToInt32(cmbOctaves.SelectedValue);
                int instrumentValue = Convert.ToInt32(cmbInstruments.SelectedValue);
                int volume = tbVolume.Value;

                long tempo = 0;
                MidiEventCollection midiEvents = new MidiEventCollection(0, 480);
                int[] meuVetor = { 0, 2, 4, 5, 7, 9, 11 };
                int BPM = 120; // Substitua pelo BPM desejado

                // Modificar os eventos de mudança de tempo na sequência
                MusicGeneratorService.AdjustBPM(midiEvents, BPM);




                Random random = new Random();



                string A_G = "ABCDEFG";



                // Atribuir os valores selecionados às variáveis
                string selectedInstrument = cmbInstruments.SelectedIndex.ToString();
                string selectedOctave = cmbOctaves.SelectedIndex.ToString();
                // string music_maiuscula = music.ToUpper();
                MessageBox.Show(music);

                bool isAbleToPlay = InputValidationService.UserInputValidation(music, instrumentValue, octaveValue);
                if (isAbleToPlay)
                {
                    for (int i = 0; i < music.Length; i++)
                    {

                        switch (music[i])
                        {

                            case 'A':

                                MusicGeneratorService.AddEventsFromText(midiEvents, 9 * (octaveValue + 1), volume, ref tempo);
                                break;
                            case 'B':
                                if (music[i + 1] == 'P' && music[i + 2] == 'M' && music[i + 3] == '+')
                                {
                                    // midiEvents(0, BPM + 80);
                                    i = i + 3;
                                }
                                else
                                {
                                    MusicGeneratorService.AddEventsFromText(midiEvents, 11 * (octaveValue + 1), volume, ref tempo);
                                }
                                break;
                            case 'C':
                                MusicGeneratorService.AddEventsFromText(midiEvents, (octaveValue + 1), volume, ref tempo);
                                break;
                            case 'D':
                                MusicGeneratorService.AddEventsFromText(midiEvents, 2 * (octaveValue + 1), volume, ref tempo);
                                break;
                            case 'E':
                                MusicGeneratorService.AddEventsFromText(midiEvents, 4 * (octaveValue + 1), volume, ref tempo);
                                break;
                            case 'F':
                                MusicGeneratorService.AddEventsFromText(midiEvents, 5 * (octaveValue + 1), volume, ref tempo);
                                break;
                            case 'G':
                                MusicGeneratorService.AddEventsFromText(midiEvents, 7 * (octaveValue + 1), volume, ref tempo);
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
                                volume = tbVolume.Value;
                                break;


                            case '\n':
                                MusicGeneratorService.ChangeInstrument(instrumentValue);
                                break;

                            case ';':
                                BPM = random.Next(60, 180);
                                MusicGeneratorService.AdjustBPM(midiEvents, BPM);

                                break;


                            case 'R':
                                if (music[i + 1] == '+')
                                {
                                    octaveValue++;
                                    i++;
                                    if (octaveValue > 12)
                                        octaveValue = 0;
                                }
                                else if (music[i + 1] == '-')
                                {
                                    i++;
                                    octaveValue--;
                                    if (octaveValue < 0)
                                        octaveValue = 12;
                                }
                                break;
                            case ' ':
                                MusicGeneratorService.AddEventsFromText(midiEvents, 7 * (octaveValue + 1), 0, ref tempo);

                                break;

                            case '?':
                                int indiceAleatorio = random.Next(0, meuVetor.Length);
                                int numeroAleatorio = meuVetor[indiceAleatorio];
                                MusicGeneratorService.AddEventsFromText(midiEvents, numeroAleatorio * (octaveValue + 1), 0, ref tempo);
                                break;
                                /* case 'O':
                                     for (int j = 0; j < A_G.Lentgh; i++)
                                     {
                                         if (music[i-1] == A_G[j])
                                         {

                                         }
                                     }*/



                        }





                    }


                    MidiOut midiOut = new MidiOut(0);
                    foreach (var midiEvent in midiEvents[0])
                    {
                        // MessageBox.Show("oi");
                        midiOut.Send(midiEvent.GetAsShortMessage());
                    }
                    MessageBox.Show("oi");
                    midiOut.Close();
                }



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