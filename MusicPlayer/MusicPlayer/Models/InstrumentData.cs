namespace MusicPlayer.Models
{
    public static class InstrumentData
    {
        public static IEnumerable<Instrument> Instruments = new List<Instrument>()
        {
            new Instrument(){ Id = 0, Name = "Piano"},
            new Instrument(){ Id = 27, Name = "Eletric Guitar"},
        };
    }
}
