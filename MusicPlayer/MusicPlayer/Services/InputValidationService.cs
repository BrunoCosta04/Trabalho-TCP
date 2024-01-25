using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    internal static class InputValidationService
    {
        //Todos os caracteres são validos. Isso pode ser útil para o GUI.
        private static readonly char[] validChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G','H','I',
                                                      'J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y',
                                                      'Z','?',';','+', '-' };
        public static bool UserInputValidation(string music, int instrumentValue, int octaveValue)
        {
            bool sucesso = true;

            StringBuilder sb = new StringBuilder();

            if (instrumentValue < 0)
            {
                sb.AppendLine("Necessário escolher um instrumento!");
                sucesso = false;
            }
                

            if (octaveValue < 0)
            {
                sb.AppendLine("Necessário escolher uma oitava!");
                sucesso = false;
            }
                

            if (!MusicCharValidator(music))
            {
                sb.AppendLine("Existem caracteres inválidos no texto!");
                sucesso = false;
            }

            if (!sucesso) 
            {   
                string errorMessage = sb.ToString();
                throw new Exception(errorMessage);
            }



            return sucesso;
        }
        //Valida se o texto excrito ou em texto não contem nenhum caractere desconhecido, que não esta na tabela ASCII.
       
        private static bool MusicCharValidator(string music)
        {
            bool sucesso = true;
            int letterValue = 0;
            if( music.Length == 0)
            {
                sucesso = false;
            }
            else{
                foreach (char letter in music)
                {
                    letterValue = (int)letter;
                    //deve retornar uma mensagem de 'caractere inválido'
                    if (!(letterValue >= 0 && letterValue <= 127))
                    {
                        sucesso = false;
                        break;
                    }
                }

            }




            return sucesso;
        }
    }
}
