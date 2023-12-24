using Project.Utility;
using UnityEngine;

namespace Project.SystemSound
{
    public class SystemSoundsManager : BasePool<SystemSoundObject>
    {
        [SerializeField] private SystemSoundObject _soundObjectPrefab;

        protected override SystemSoundObject CreatePoolObj()
        {
            SystemSoundObject poolObj = Instantiate(_soundObjectPrefab, transform);
            poolObj.Init(_pool);
            return poolObj;
        }

        public void PlaySystemSound(AudioClip audioClip)
        {
            if (audioClip == null) return;
            _pool.Get().PlaySound(audioClip);
        }
    }
}
