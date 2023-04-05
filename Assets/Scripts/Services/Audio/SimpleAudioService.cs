using UnityEngine;

namespace TW.Services.Audio
{
    public class SimpleAudioService : IAudioService
    {
        private readonly Transform _parent;
        private AudioSource _singleAudioSource;

        public SimpleAudioService(Transform parent)
        {
            _parent = parent;
        }

        public void Bootstrap()
        {
            var go = new GameObject("SingleAudioSource");
            go.transform.SetParent(_parent);
            _singleAudioSource = go.AddComponent<AudioSource>();
        }

        public void PlaySfx(string path)
        {
            var clip = Resources.Load<AudioClip>(path);
            if (clip == null)
            {
                return;
            }

            _singleAudioSource.PlayOneShot(clip);
        }
    }
}