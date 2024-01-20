using UniRx;

namespace Project.UI.MVVM
{
	public abstract class AudioSettingsBaseViewModel
	{
		protected AudioSettingsBaseModel _model;
		protected CompositeDisposable _disposables = new();

		public ReactiveProperty<float> MasterVolumeView { get; protected set; } = new();

		public AudioSettingsBaseViewModel(AudioSettingsBaseModel model)
        {
			_model = model;
			_model.MasterVolume.Subscribe(v => MasterVolumeView.Value = v).AddTo(_disposables);
        }

		public void SetMasterVolume(float v)
        {
			if (v < 0 || v > 1) return;
			MasterVolumeView.Value = v;
        }

		public void ApplyChanges()
        {
			_model.SetMasterVolume(MasterVolumeView.Value);
        }

		public void ResetChanges()
		{
			MasterVolumeView.Value = _model.MasterVolume.Value;
		}
	}
}
