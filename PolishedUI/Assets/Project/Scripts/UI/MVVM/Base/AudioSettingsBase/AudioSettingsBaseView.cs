using UnityEngine;
using UniRx;

namespace Project.UI.MVVM
{
	public abstract class AudioSettingsBaseView : MonoBehaviour
	{
		protected AudioSettingsBaseViewModel _viewModel;
		protected CompositeDisposable _disposables = new();

		protected virtual void Init(AudioSettingsBaseViewModel viewModel)
        {
			_viewModel = viewModel;
			_viewModel.MasterVolumeView.Subscribe(v => Display(v)).AddTo(_disposables);
        }

		public abstract void SetMasterVolume(float v);

		public abstract void Display(float v);
	}
}
