using TW.Game;
using Zenject;

namespace TW.Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameControllerInstaller.Install(Container);
        }
    }
}