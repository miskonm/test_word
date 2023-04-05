using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace TW.Services.Ui.Views.Game
{
    public class GameLevelCell : MonoBehaviour
    {
        [SerializeField] private float _rotationTime = 1;
        
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private CanvasGroup _frontImageCanvasGroup;
        [SerializeField] private CanvasGroup _backImageCanvasGroup;
        
        private RectTransform _rectTransform;
        private Tween _rotationTween;
        private bool _isFaceVisible;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetCharacter(string character)
        {
            _label.text = character;
        }

        public void SetBackward()
        {
            _rectTransform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            CalculateLook();
        }

        public async UniTask ShowFace(CancellationToken token)
        {
            if (_isFaceVisible)
            {
                return;
            }
            
            await _rectTransform
                .DOLocalRotate(Vector3.zero, _rotationTime)
                .OnUpdate(CalculateLook)
                .WithCancellation(token);
        }
        
        public async UniTask ShowBack(CancellationToken token)
        {
            if (!_isFaceVisible)
            {
                return;
            }
            
            await _rectTransform
                .DOLocalRotate(new Vector3(0, 180, 0), _rotationTime)
                .OnUpdate(CalculateLook)
                .WithCancellation(token);
        }

        private void CalculateLook()
        {
            var eulerAnglesY = _rectTransform.localRotation.eulerAngles.y;
            if (_isFaceVisible && IsBackAngle(eulerAnglesY))
            {
                _isFaceVisible = false;
            }
            else if(!_isFaceVisible && IsFaceAngle(eulerAnglesY))
            {
                _isFaceVisible = true;
            }

            UpdateLook();

            bool IsFaceAngle(float yAngle)
            {
                return (yAngle > -90 && yAngle < 90) || (yAngle > 270 && yAngle <= 360) || (yAngle >= 360 && yAngle < -270);
            }
            
            bool IsBackAngle(float yAngle)
            {
                return (yAngle >= 90 && yAngle <= 270) || (yAngle >= -270 && yAngle <= -90);
            }
        }
        

        private void UpdateLook()
        {
            _frontImageCanvasGroup.alpha = _isFaceVisible ? 1 : 0;
            _backImageCanvasGroup.alpha = _isFaceVisible ? 0 : 1;
        }

        [Button()]
        private void ShowFace()
        {
            ShowFace(CancellationToken.None).Forget();
        }
        
        [Button()]
        private void ShowBack()
        {
            ShowBack(CancellationToken.None).Forget();
        }
    }
}