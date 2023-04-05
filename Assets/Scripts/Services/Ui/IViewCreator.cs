using TW.Services.Ui.Views;

namespace TW.Services.Ui
{
    public interface IViewCreator
    {
        TView Create<TView>() where TView : View;
    }
}