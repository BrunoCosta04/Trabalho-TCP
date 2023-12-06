namespace MusicPlayer.Models
{
    public class OctaveData
    {
        public static IEnumerable<Octave> Octaves = new List<Octave>()
        {
            new Octave(){ Id = 0, Name = "Zero"},
            new Octave(){ Id = 1, Name = "First"},
            new Octave(){ Id = 2, Name = "Second"},
            new Octave(){ Id = 3, Name = "Third"},
            new Octave(){ Id = 4, Name = "Fourth"},
            new Octave(){ Id = 5, Name = "Fifth"},
            new Octave(){ Id = 6, Name = "Sixth"},
            new Octave(){ Id = 7, Name = "Seventh"},
            new Octave(){ Id = 8, Name = "Eighth"},
            new Octave(){ Id = 9, Name = "Nineth"},
            new Octave(){ Id = 10, Name = "Tenth"}
        };
    }
}
