using System.Threading;
using Cysharp.Threading.Tasks;
using TW.Services.Config.Data;

namespace TW.Services.Config
{
    public interface IConfigLoader
    {
        UniTask<LevelConfig> Load(CancellationToken ct = default);
    }
}