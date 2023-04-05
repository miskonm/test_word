using TW.Services.Config.Data;
using TW.Services.Ui;
using TW.Services.Ui.Views.Game;

namespace TW.Game.Error
{
    public class ShakeErrorHandler : BaseErrorHandler<ShakeErrorConfig>
    {
        private readonly IUiService _uiService;

        public ShakeErrorHandler(IUiService uiService)
        {
            _uiService = uiService;
        }
        protected override void Perform(ShakeErrorConfig errorConfig)
        {
            var gameViewController = _uiService.GetController<GameViewController>();
            gameViewController.ShakeLevel(errorConfig.Time);
        }
    }
}