using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace TW.Infrastructure.SceneLoading
{
    public class AsyncSceneLoader : ISceneLoader
    {
        public async UniTask LoadScene(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName).ToUniTask();
        }
    }
}