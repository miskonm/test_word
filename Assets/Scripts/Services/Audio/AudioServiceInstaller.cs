using UnityEngine;
using Zenject;

namespace TW.Services.Audio
{
    public class AudioServiceInstaller : MonoInstaller
    {
        [SerializeField] private Transform _parent;
        
        public override void InstallBindings()
        {
            Container.Bind<IAudioService>().To<SimpleAudioService>().AsSingle().WithArguments(_parent);
        }
    }
}