using Project.SystemSound;
using UnityEngine;
using Zenject;

namespace Project.UI.Buttons
{
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] private BtnSoundsConfig _BtnSoundsConfig;
        private SystemSoundsManager _soundsManager;

        [Inject]
        private void Construct(SystemSoundsManager soundsManager) => _soundsManager = soundsManager;

        public virtual void OnClick() => _soundsManager.PlaySystemSound(_BtnSoundsConfig.SubmitSound);

        public virtual void OnSelect() => _soundsManager.PlaySystemSound(_BtnSoundsConfig.SelectSound);

        public virtual void OnDiselect() => _soundsManager.PlaySystemSound(_BtnSoundsConfig.SelectSound);
    }
}
