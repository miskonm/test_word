using Zenject;

namespace TW.Infrastructure.SceneLoading
{
    public class SceneLoaderInstaller : Installer<SceneLoaderInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<AsyncSceneLoader>().AsSingle();
        }
    }
}