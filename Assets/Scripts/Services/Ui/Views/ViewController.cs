using UnityEngine.Assertions;
using Zenject;
using Object = UnityEngine.Object;

namespace TW.Services.Ui.Views
{
    public abstract class ViewController
    {
        public abstract void Show();
        public abstract void Hide();
    }

    public abstract class ViewController<TView> : ViewController where TView : View
    {
        private IViewCreator _viewCreator;
        protected TView View { get; private set; }

        [Inject]
        public void SetCreator(IViewCreator viewCreator)
        {
            _viewCreator = viewCreator;
        }

        public sealed override void Show()
        {
            Assert.IsNull(View, $"View already shown {typeof(TView)}");
            View = _viewCreator.Create<TView>();
            OnShowed();
        }

        public sealed override void Hide()
        {
            OnHiding();
            Assert.IsNotNull(View, $"View already hidden {typeof(TView)}");
            Object.Destroy(View);
            View = null;
        }

        protected virtual void OnShowed()
        {
        }

        protected virtual void OnHiding()
        {
        }
    }
}