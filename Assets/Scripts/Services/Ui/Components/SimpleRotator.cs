using DG.Tweening;
using UnityEngine;

namespace TW.Services.Ui.Components
{
    public class SimpleRotator : MonoBehaviour
    {
        [SerializeField] private float _rotationTime;
        [SerializeField] private Ease _ease = Ease.Linear;
        
        private Tween _rotationTween;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable() => 
            StartTween();

        private void OnDisable() =>
            StopTween();

        private void StartTween()
        {
            _rotationTween = _rectTransform
                .DORotate(new Vector3(0, 0, 360), _rotationTime, RotateMode.FastBeyond360)
                .ChangeStartValue(Vector3.zero)
                .SetEase(_ease)
                .SetLoops(-1);
        }

        private void StopTween() => 
            _rotationTween?.Kill();
    }
}
