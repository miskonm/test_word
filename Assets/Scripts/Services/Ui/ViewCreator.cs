using TW.Services.Ui.Views;
using UnityEngine;

namespace TW.Services.Ui
{
    public class ViewCreator : IViewCreator
    {
        private readonly Transform _parentTransform;

        public ViewCreator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }
        
        public TView Create<TView>() where TView : View
        {
            var path = $"Ui/{typeof(TView).Name}";
            var prefab = Resources.Load<TView>(path);

            if (prefab != null)
            {
                return Object.Instantiate(prefab, _parentTransform);
            }
            
            Debug.LogError($"Couldn't load prefab at '{path}' with type {typeof(TView)}");
            return null;
        }
    }
}