using Project.Sound.Configs;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Project.Sound
{
    public class SystemSoundsManager : MonoBehaviour
    {
        [SerializeField] private SystemSoundObject _systemSoundObjectPrefab;
        [SerializeField] private AudioClip clip;

        public static ObjectPool<SystemSoundObject> SystemSoundsPool;
        public ObjectPool<SystemSoundObject> SystemSoundsPoolRef => SystemSoundsPool;

        [Inject]
        private void Construct()
        {
            Debug.Log("SoundManager");
            SystemSoundsPool = new ObjectPool<SystemSoundObject>(CreateSound, TakeSoundFromPool, ReternSoundToPool, DestroySound, true, 10, 100);
        }

        private SystemSoundObject CreateSound()
        {
            SystemSoundObject soundObject = Instantiate(_systemSoundObjectPrefab);
            soundObject.Init(SystemSoundsPool);
            return soundObject;
        }

        private void TakeSoundFromPool(SystemSoundObject soundObject)
        {
            soundObject.PlaySound(clip);
        }

        private void ReternSoundToPool(SystemSoundObject soundObject)
        {
            soundObject.gameObject.SetActive(false);
        }

        private void DestroySound(SystemSoundObject soundObject)
        {
            Destroy(soundObject);
        }
    }
}
