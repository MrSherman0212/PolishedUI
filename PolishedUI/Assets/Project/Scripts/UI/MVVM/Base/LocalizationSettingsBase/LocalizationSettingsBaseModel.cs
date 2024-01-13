using UniRx;

namespace Project.UI.MVVM
{
	public abstract class LocalizationSettingsBaseModel
	{
		private LocaleSelector _localeSelector;
		private ReactiveProperty<int> _localeID = new();
        public ReactiveProperty<int> LocaleID => _localeID;

		public LocalizationSettingsBaseModel(LocaleSelector localeSelector)
        {
			_localeID.Value = 0;
			_localeSelector = localeSelector;
        }

		public void SetLocaleID(int localeID)
        {
			_localeID.Value = localeID;
			_localeSelector.ChangeLocale(localeID);
        }
	}
}
