using TW.Services.Audio;
using TW.Services.Config.Data;

namespace TW.Game.Error
{
    public class SoundErrorHandler : BaseErrorHandler<SoundErrorConfig>
    {
        private readonly IAudioService _audioService;

        public SoundErrorHandler(IAudioService audioService)
        {
            _audioService = audioService;
        }

        protected override void Perform(SoundErrorConfig errorConfig) => 
            _audioService.PlaySfx(errorConfig.SoundPath);
    }
}