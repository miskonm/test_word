using Zenject;

namespace TW.Services.Ui
{
    public class ViewControllerFactory
    {
        private readonly IInstantiator _instantiator;

        public ViewControllerFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public TController Create<TController>() => 
            _instantiator.Instantiate<TController>();
    }
}