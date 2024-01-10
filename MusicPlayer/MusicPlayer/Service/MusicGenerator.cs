namespace MusicPlayer.Service
{
    public class MusicGenerator : IMusicGenerator
    {
        public int OctaveDefault { get; private set; }
        public MusicGenerator(int octaveDefault)
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
