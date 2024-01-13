using UnityEngine;
using Zenject;
using UniRx;

namespace Project.UI.MVVM
{
	public abstract class LocalizationSettingsBaseView : MonoBehaviour
	{
		protected LocalizationSettingsBaseViewModel _viewModel;
		protected CompositeDisposable _disposables = new();

		[Inject]
        protected virtual void Init(LocalizationSettingsBaseViewModel viewModel)
		{
			_viewModel = viewModel;

			_viewModel.LocaleIDView.Subscribe(v => DisplayLocales()).AddTo(_disposables);
        }

		protected abstract void SetLocaleID();

		protected abstract void DisplayLocales();
	}
}
