using Cysharp.Threading.Tasks;

namespace TW.Infrastructure.SceneLoading
{
    public interface ISceneLoader
    {
        UniTask LoadScene(string sceneName);
    }
}