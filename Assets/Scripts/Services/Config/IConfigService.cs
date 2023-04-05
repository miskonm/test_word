using System.Threading;
using Cysharp.Threading.Tasks;
using TW.Services.Config.Data;

namespace TW.Services.Config
{
    public interface IConfigService
    {
        UniTask LoadConfigs(CancellationToken ct = default);
        LevelConfig GetLevelConfig();
    }
}