namespace MusicPlayer.Models
{
    public class Music
    {
        public required int Id { get; set; }
        public required string Text { get; set; }
        public required int Octave { get; set; }
        public required int Instrument { get; set; }
        public required int Volume { get; set; }
        public required bool IsPlaying { get; set; }
        public required bool IsPaused { get; set; }
        public required bool IsStopped { get; set; }

        //public Music() { }
        //public Music(string text, int octave, int volume, int instrument)
        //{
        //    Text = text;
        //    Octave = octave;
        //    Volume = volume;
        //    Instrument = instrument;
        //    IsPlaying = true;
        //    IsPaused = false;
        //    IsStopped = false;
        //}
    }
}
