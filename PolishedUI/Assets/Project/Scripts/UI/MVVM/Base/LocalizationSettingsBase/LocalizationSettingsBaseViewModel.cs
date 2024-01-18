using UniRx;

namespace Project.UI.MVVM
{
	public abstract class LocalizationSettingsBaseViewModel
	{
		protected LocalizationSettingsBaseModel _model;
		protected CompositeDisposable _disposables = new();
		public ReactiveProperty<int> LocaleIDView = new();

		public LocalizationSettingsBaseViewModel(LocalizationSettingsBaseModel model)
        {
			_model = model;
			_model.LocaleID.Subscribe(v => { SetLocaleID(v); }).AddTo(_disposables);
        }

		public void SetLocaleID(int localeIDView)
        {
			LocaleIDView.Value = localeIDView;
        }

		public void SubmitLocaleID()
        {
			_model.SetLocaleID(LocaleIDView.Value);
        }

		public void ResetLocaleID()
        {
			SetLocaleID(_model.LocaleID.Value);
        }
	}
}
