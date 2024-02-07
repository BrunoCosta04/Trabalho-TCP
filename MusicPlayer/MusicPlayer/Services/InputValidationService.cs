using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    internal static class InputValidationService
    {
        public static bool UserInputValidation(string music, int instrumentSelectedValue, int octaveSelectedValue)
        {
            bool sucesso = true;
            int number = 0;
            StringBuilder sb = new StringBuilder();

            if (instrumentSelectedValue < 0)
            {
                number++;
                sb.AppendLine("Necessário escolher um instrumento!");
                sucesso = false;
            }

            if (octaveSelectedValue < 0)
            {
                number++;
                sb.AppendLine("Necessário escolher uma oitava!");
                sucesso = false;
            }

            if (!MusicCharValidator(music))
            {
                number++;
                sb.AppendLine("O texto está vazio ou contém caracteres inválidos!");
                sucesso = false;
            }

            if (!sucesso)
            {
                sb.Insert(0, $"Existem {number} erro(s) em seu pedido: \n");
                string errorMessage = sb.ToString();
                MessageBox.Show(errorMessage);
            }

            return sucesso;
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
    }
}

