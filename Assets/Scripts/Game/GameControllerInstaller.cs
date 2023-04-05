using TW.Game.Error;
using TW.Game.Success;
using TW.Game.Validation;
using Zenject;

namespace TW.Game
{
    public class GameControllerInstaller : Installer<GameControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameStarter>().AsSingle().NonLazy();
            
            Container
                .Bind<IGameController>()
                .FromSubContainerResolve()
                .ByMethod(InstallService)
                .AsSingle();
        }

        private void InstallService(DiContainer subContainer)
        {
            subContainer.Bind<IGameController>().To<GameController>().AsSingle();

            subContainer
                .Bind<IErrorModule>()
                .FromSubContainerResolve()
                .ByMethod(InstallError)
                .AsSingle();
            
            subContainer.Bind<ISuccessModule>().To<OpenUiSuccessModule>().AsSingle();
            subContainer
                .Bind<IValidationModule>()
                .FromSubContainerResolve()
                .ByMethod(InstallValidation)
                .AsSingle();
        }

        private void InstallError(DiContainer subContainer)
        {
            subContainer.Bind<IErrorModule>().To<ErrorModule>().AsSingle();

            subContainer.Bind<IErrorHandler>().To<SoundErrorHandler>().AsSingle();
            subContainer.Bind<IErrorHandler>().To<ShakeErrorHandler>().AsSingle();
        }

        private void InstallValidation(DiContainer subController)
        {
            subController.Bind<IValidationModule>().To<ValidationModule>().AsSingle();
            subController.Bind<IValidationAlgorithm>().To<SimpleValidationAlgorithm>().AsSingle();
        }
    }
}