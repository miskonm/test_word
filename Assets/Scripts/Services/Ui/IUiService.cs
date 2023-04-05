using TW.Services.Ui.Views;

namespace TW.Services.Ui
{
    public interface IUiService
    {
        TController GetController<TController>() where TController : ViewController;
    }
}