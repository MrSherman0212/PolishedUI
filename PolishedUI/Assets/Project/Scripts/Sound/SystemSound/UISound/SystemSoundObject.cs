using System.Collections;
using UnityEngine.Pool;
using UnityEngine;

namespace Project.SystemSound
{
    [RequireComponent(typeof(AudioSource))]
    public class SystemSoundObject : MonoBehaviour, IPoolable
    {
        private AudioSource _audioSource;
        private ObjectPool<SystemSoundObject> _soundsPool;

        public void Init(ObjectPool<SystemSoundObject> soundsPool)
        {
            _soundsPool = soundsPool;
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip audioClip)
        {
            if (audioClip == null)
            {
                _soundsPool.Release(this);
                return;
            }
            _audioSource.clip = audioClip;
            _audioSource.Play();
            StartCoroutine(DeactivateSoundByTime(audioClip.length));
        }

        private IEnumerator DeactivateSoundByTime(float lifeTime)
        {
            yield return new WaitForSeconds(lifeTime);
            _soundsPool.Release(this);
        }
    }
}
