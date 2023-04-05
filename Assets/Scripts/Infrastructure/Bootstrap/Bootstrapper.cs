using Cysharp.Threading.Tasks;
using TW.Infrastructure.SceneLoading;
using TW.Services.Config;
using Zenject;

namespace TW.Infrastructure.Bootstrap
{
    public class Bootstrapper : IInitializable
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IConfigService _configService;
        
        public Bootstrapper(ISceneLoader sceneLoader, IConfigService configService)
        {
            _sceneLoader = sceneLoader;
            _configService = configService;
        }
        
        public void Initialize()
        {
            BootstrapAsync().Forget();
        }
        
        private async UniTask BootstrapAsync()
        {
            await _configService.LoadConfigs();
            await UniTask.Delay(1000);
            await _sceneLoader.LoadScene(SceneName.Game);
        }
    }
}