using TW.Game.Error;
using TW.Game.Success;
using TW.Game.Validation;
using TW.Services.Config;
using TW.Services.Config.Data;
using TW.Services.Ui;
using TW.Services.Ui.Views.Game;

namespace TW.Game
{
    public class GameController : IGameController
    {
        private readonly IConfigService _configService;
        private readonly IUiService _uiService;
        private readonly IValidationModule _validationModule;
        private readonly IErrorModule _errorModule;
        private readonly ISuccessModule _successModule;

        private LevelConfig _levelConfig;

        public GameController(IConfigService configService, IUiService uiService, IValidationModule validationModule,
            IErrorModule errorModule, ISuccessModule successModule)
        {
            _configService = configService;
            _uiService = uiService;
            _validationModule = validationModule;
            _errorModule = errorModule;
            _successModule = successModule;
        }

        public void Start()
        {
            _levelConfig = _configService.GetLevelConfig();
            _validationModule.Bootstrap(_levelConfig.WordsConfig);
            var gameViewController = _uiService.GetController<GameViewController>();
            gameViewController.OkButtonClickedEvent += OnOkButtonClicked;
            gameViewController.SetWords(_levelConfig.WordsConfig);
            gameViewController.Show();
        }


        private void ValidateWord(string word)
        {
            var validationResult = _validationModule.Validate(word);
            if (validationResult.Status == ValidationStatus.Fail)
            {
                _errorModule.Perform(_levelConfig.ErrorConfig);
            }
            else
            {
                _successModule.Perform(validationResult);
            }
        }

        private void OnOkButtonClicked(string word) => 
            ValidateWord(word);
    }
}