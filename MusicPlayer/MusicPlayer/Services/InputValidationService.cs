using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MusicPlayer.Services
{
    internal static class InputValidationService
    {
        public static bool UserInputValidation(string music, int instrumentSelectedValue, int octaveSelectedValue)
        {
            bool success = true;
            int number = 0;
            StringBuilder sb = new StringBuilder();

            if (instrumentSelectedValue < 0)
            {
                number++;
                sb.AppendLine("Necessário escolher um instrumento!");
                success = false;
            }

            if (octaveSelectedValue < 0)
            {
                number++;
                sb.AppendLine("Necessário escolher uma oitava!");
                success = false;
            }

            if (!MusicCharValidator(music))
            {
                number++;
                sb.AppendLine("O texto está vazio ou contém caracteres inválidos!");
                success = false;
            }

            if (!success)
            {
                sb.Insert(0, $"Existem {number} erro(s) em seu pedido: \n");
                string errorMessage = sb.ToString();
                MessageBox.Show(errorMessage);
            }

            return success;
        }

        //Valida se o texto excrito ou em texto não contem nenhum caractere desconhecido, que não esta na tabela ASCII.
        private static bool MusicCharValidator(string music)
        {
            bool success = true;

            int letterValue;
            if (string.IsNullOrEmpty(music))
                return false;

            foreach (char letter in music)
            {
                letterValue = (int)letter;

                if (!(letterValue >= 0 && letterValue <= 127))
                    return false;
            }

            return success;
        }

        public static bool MusicValidation(MidiEventCollection music)
        {
            bool success = true;
            StringBuilder sb = new StringBuilder();

            if (music == null)
            {
                sb.AppendLine("É necessário gerar a música antes de tocar!");
                success = false;
            }

            if (!success)
            {
                string errorMessage = sb.ToString();
                MessageBox.Show(errorMessage);
            }

            return success;
        }
    }
}

