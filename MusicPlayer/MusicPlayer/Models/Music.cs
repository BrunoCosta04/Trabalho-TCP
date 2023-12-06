namespace MusicPlayer.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public byte[] NewText { get; set; } 
    }
}
