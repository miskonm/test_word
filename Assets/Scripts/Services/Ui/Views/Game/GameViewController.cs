using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TW.Game.Validation;
using TW.Services.Config.Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TW.Services.Ui.Views.Game
{
    public class GameViewController : ViewController<GameView>
    {
        private WordsConfig _config;
        private GameLevelCell[][] _cells;

        public event Action<string> OkButtonClickedEvent;

        public void SetWords(WordsConfig config)
        {
            _config = config;
        }

        public void SetInteractableButton(bool isActive) =>
            View.OkButton.interactable = isActive;

        public async UniTask OpenCells(Vector2Int startPosition, int length, Direction direction,
            CancellationToken token)
        {
            for (int i = 0; i < length; i++)
            {
                var lineIndex = direction == Direction.Down ? startPosition.x + i : startPosition.x;
                var columnIndex = direction == Direction.Right ? startPosition.y + i : startPosition.y;

                await _cells[lineIndex][columnIndex].ShowFace(token);
            }
        }

        protected override void OnShowed()
        {
            base.OnShowed();

            CreateLevel();
            View.OkButton.onClick.AddListener(OnButtonClicked);
        }

        protected override void OnHiding()
        {
            base.OnHiding();

            View.OkButton.onClick.RemoveListener(OnButtonClicked);
        }

        private void CreateLevel()
        {
            var configWordsWire = _config.WordsWire;
            _cells = new GameLevelCell[configWordsWire.Length][];

            for (int i = 0; i < configWordsWire.Length; i++)
            {
                var line = configWordsWire[i];
                var cellsLine = new GameLevelCell[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    var cell = Object.Instantiate(View.CellPrefab, View.LevelCellParent);
                    cell.SetCharacter(character);
                    cell.SetBackward();
                    cellsLine[j] = cell;
                }

                _cells[i] = cellsLine;
            }
        }

        private void OnButtonClicked()
        {
            if (string.IsNullOrEmpty(View.InputText))
            {
                return;
            }

            OkButtonClickedEvent?.Invoke(View.InputText);
        }
    }
}