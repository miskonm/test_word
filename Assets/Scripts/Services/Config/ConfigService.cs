using System.Threading;
using Cysharp.Threading.Tasks;
using TW.Services.Config.Data;

namespace TW.Services.Config
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigLoader _loader;
        private LevelConfig _config;

        public ConfigService(IConfigLoader configLoader)
        {
            _loader = configLoader;
        }
        
        public async UniTask LoadConfigs(CancellationToken ct = default)
        {
            _config = await _loader.Load(ct);
        }

        public LevelConfig GetLevelConfig() =>
            _config;
    }
}