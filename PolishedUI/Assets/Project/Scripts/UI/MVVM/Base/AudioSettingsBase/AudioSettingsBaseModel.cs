using UniRx;

namespace Project.UI.MVVM
{
	public abstract class AudioSettingsBaseModel
	{
		private ReactiveProperty<float> _masterVolume = new();

		public ReactiveProperty<float> MasterVolume => _masterVolume;

		public abstract void SetMasterVolume(float v);
	}
}
