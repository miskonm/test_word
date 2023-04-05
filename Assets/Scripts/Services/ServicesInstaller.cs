using TW.Infrastructure.SceneLoading;
using TW.Services.Config;
using TW.Services.Ui;
using Zenject;

namespace TW.Services
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SceneLoaderInstaller.Install(Container);
            ConfigServiceInstaller.Install(Container);
        }
    }
}