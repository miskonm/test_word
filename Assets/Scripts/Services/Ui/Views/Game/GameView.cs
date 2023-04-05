using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TW.Services.Ui.Views.Game
{
    public class GameView : View
    {
        [Header("Level")] 
        [SerializeField] private RectTransform _levelCellParent;
        [SerializeField] private GameLevelCell _cellPrefab;
        
        [Header("Input")] 
        [SerializeField] private Button _okButton;
        [SerializeField] private TMP_InputField _inputField;
        

        public RectTransform LevelCellParent => _levelCellParent;
        public GameLevelCell CellPrefab => _cellPrefab;

        public Button OkButton => _okButton;
        public string InputText => _inputField.text;
    }
}