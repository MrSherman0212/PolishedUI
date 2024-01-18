using UnityEngine;
using UniRx;

namespace Project.UI.MVVM
{
	public abstract class LocalizationSettingsBaseView : MonoBehaviour
	{
		protected LocalizationSettingsBaseViewModel _viewModel;
		protected CompositeDisposable _disposables = new();
		
        protected virtual void Init(LocalizationSettingsBaseViewModel viewModel)
		{
			_viewModel = viewModel;
			_viewModel.LocaleIDView.Subscribe(v => DisplayLocales()).AddTo(_disposables);
        }

		protected abstract void SetLocaleID(int v);

		protected abstract void DisplayLocales();
	}
}
