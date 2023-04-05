using System.Threading;
using Cysharp.Threading.Tasks;
using TW.Game.Validation;
using TW.Services.Ui;
using TW.Services.Ui.Views.Game;
using UnityEngine;

namespace TW.Game.Success
{
    public class OpenUiSuccessModule : ISuccessModule
    {
        private readonly IUiService _uiService;

        public OpenUiSuccessModule(IUiService uiService)
        {
            _uiService = uiService;
        }
        public void Perform(ValidationResult validationResult)
        {
            Debug.LogError($"Success with data StartPosition = {validationResult.StartPosition}, Length = {validationResult.Length}");
            
            OpenUiAsync(validationResult).Forget();
        }

        private async UniTask OpenUiAsync(ValidationResult validationResult)
        {
            var gameViewController = _uiService.GetController<GameViewController>();
            gameViewController.SetInteractableButton(false);
            await gameViewController.OpenCells(validationResult.StartPosition, validationResult.Length,
                validationResult.Direction, CancellationToken.None);
            gameViewController.SetInteractableButton(true);
        }
    }
}