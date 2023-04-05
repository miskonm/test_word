using UnityEngine;
using Zenject;

namespace TW.Services.Ui
{
    public class UiServiceInstaller : MonoInstaller
    {
        [SerializeField] private Transform _parentTransform;

        public override void InstallBindings()
        {
            Container
                .Bind<IUiService>()
                .FromSubContainerResolve()
                .ByMethod(InstallService)
                .AsSingle();
        }

        private void InstallService(DiContainer subContainer)
        {
            subContainer.Bind<IUiService>().To<SimpleUiService>().AsSingle();
            subContainer.Bind<ViewControllerFactory>().AsSingle();
            subContainer.Bind<IViewCreator>().To<ViewCreator>().AsSingle().WithArguments(_parentTransform);
        }
    }
}