namespace MusicPlayer.Models
{   //pode ter aqui como atributo a ação que deve ser tomada com cada caractere.
    public class Compiler
    {
        public int OctaveDefault { get; private set; }
        public Compiler(int octaveDefault)
        {
            OctaveDefault = octaveDefault;
        }
        public string MusicConverter(string text)
        {
            string newText = string.Empty;

            //faz alguma coisa

            return newText;
        }
        private int ReturnNewNote(int note, int octave)
        {
            int newNote = 0;





            return newNote;
        }
    }
}
