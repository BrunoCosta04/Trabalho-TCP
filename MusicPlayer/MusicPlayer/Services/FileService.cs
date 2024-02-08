using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    public static class FileService
    {
        //parametro de music event collection
        public static void Download(MidiEventCollection midiEvents, string outputPath)
        {
            if (InputValidationService.MusicValidation(midiEvents))
                MidiFile.Export(outputPath, midiEvents);
        }

        public static string Upload()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string extension = Path.GetExtension(dialog.FileName);

                if (extension.ToLower() == ".txt")
                {
                    string conteudoTxt = string.Empty;

                    using (var file = new StreamReader(dialog.OpenFile()))
                    {
                        conteudoTxt = file.ReadToEnd();
                    }

                    return conteudoTxt;
                }
                else
                    throw new Exception("Erro no arquivo! Apenas arquivos TXT!");
            }
            else
                throw new Exception("Erro ao procurar o arquivo!");
        }
    }
}
