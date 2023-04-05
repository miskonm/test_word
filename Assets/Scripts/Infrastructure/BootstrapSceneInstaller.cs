using TW.Infrastructure.Bootstrap;
using Zenject;

namespace TW.Infrastructure
{
    public class BootstrapSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Bootstrapper>().AsSingle();
        }
    }
}