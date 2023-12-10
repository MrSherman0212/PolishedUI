using UnityEngine;
using System.Collections;
using UnityEngine.Pool;

namespace Project.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SystemSoundObject : MonoBehaviour
    {
        private AudioSource _audioSource;
        private float _lifetime;
        private ObjectPool<SystemSoundObject> _systemSoundsManager;

        public void Init(ObjectPool<SystemSoundObject> systemSoundsManager)
        {
            _systemSoundsManager = systemSoundsManager;
            _audioSource = GetComponent<AudioSource>();
            Debug.Log("sound is created");
        }

        public void PlaySound(AudioClip audioClip)
        {
            _lifetime = audioClip.length;
            Debug.Log($"{_lifetime}s");

            _audioSource.clip = audioClip;
            _audioSource.Play();

            DeactivateSoundAfterTime();
        }

        private IEnumerator DeactivateSoundAfterTime()
        {
            float timer = 0;
            while (timer <= _lifetime)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            _systemSoundsManager.Release(this);
        }
    }
}
