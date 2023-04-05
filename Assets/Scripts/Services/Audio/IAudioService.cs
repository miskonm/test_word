namespace TW.Services.Audio
{
    public interface IAudioService
    {
        void Bootstrap();
        void PlaySfx(string path);
    }
}