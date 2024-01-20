using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    internal static class InputValidationService
    {
        //continuar
        private static readonly string[] validChars = { "A", "B" , "C", "D", "E", "F", "G", " ",
                                                        "+", "-", };
        public static bool UserInputValidation(string music, int instrumentSelectedValue, int octaveSelectedValue)
        {
            bool sucesso = true;

            StringBuilder sb = new StringBuilder();

            if (instrumentSelectedValue < 0)
                sb.AppendLine("Necessário escolher um instrumento!");

            if (octaveSelectedValue < 0)
                sb.AppendLine("Necessário escolher uma oitava!");




            return sucesso;
        }

        private static bool MusicCharValidator(string music)
        {
            bool sucesso = true;


            return sucesso;
        }
    }
}
