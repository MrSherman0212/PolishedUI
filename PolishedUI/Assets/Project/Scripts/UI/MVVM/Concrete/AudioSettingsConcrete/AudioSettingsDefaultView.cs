using UnityEngine.UI;
using UnityEngine;
using Zenject;
using UniRx;

namespace Project.UI.MVVM
{
	public class AudioSettingsDefaultView : AudioSettingsBaseView
	{
        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private BaseButton _applyBtn;
        [SerializeField] private BaseButton _cancelBtn;

        [Inject]
        private void Construct(AudioSettingsDefaultViewModel viewModel)
        {
            Init(viewModel);
            _masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
            _applyBtn.OnTriggerBtn.Subscribe(v => _viewModel.ApplyChanges()).AddTo(_disposables);
            _cancelBtn.OnTriggerBtn.Subscribe(v => _viewModel.ResetChanges()).AddTo(_disposables);
        }

        public override void SetMasterVolume(float v)
        {
            _viewModel.SetMasterVolume(v);
        }

        public override void Display(float v)
        {
            _masterVolumeSlider.value = v;
        }
    }
}
