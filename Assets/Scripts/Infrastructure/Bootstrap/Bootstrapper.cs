using Cysharp.Threading.Tasks;
using TW.Infrastructure.SceneLoading;
using TW.Services.Audio;
using TW.Services.Config;
using Zenject;

namespace TW.Infrastructure.Bootstrap
{
    public class Bootstrapper : IInitializable
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IConfigService _configService;
        private readonly IAudioService _audioService;

        public Bootstrapper(ISceneLoader sceneLoader, IConfigService configService, IAudioService audioService)
        {
            _sceneLoader = sceneLoader;
            _configService = configService;
            _audioService = audioService;
        }
        
        public void Initialize()
        {
            BootstrapAsync().Forget();
        }
        
        private async UniTask BootstrapAsync()
        {
            _audioService.Bootstrap();
            await _configService.LoadConfigs();
            await UniTask.Delay(1000);
            await _sceneLoader.LoadScene(SceneName.Game);
        }
    }
}