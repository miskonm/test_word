using Zenject;

namespace TW.Services.Config
{
    public class ConfigServiceInstaller : Installer<ConfigServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IConfigService>()
                .FromSubContainerResolve()
                .ByMethod(InstallService)
                .AsSingle();
        }

        private void InstallService(DiContainer subContainer)
        {
            subContainer.Bind<IConfigService>().To<ConfigService>().AsSingle();
            subContainer.Bind<IConfigLoader>().To<LocalFileConfigLoader>().AsSingle();
        }
    }
}