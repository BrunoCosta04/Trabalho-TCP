namespace MusicPlayer.Models.Interface
{
    public interface IMusicPlayer
    {
        void Play();
        void Stop();
        void Pause();
        void ChangeVolume();
    }
}
