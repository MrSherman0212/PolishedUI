using Project.Utility;
using UniRx;

namespace Project.UI.MVVM
{
	public abstract class LocalizationSettingsBaseModel
	{
		private LocaleSelector _localeSelector = new();
		private ReactiveProperty<int> _localeID = new();
        public ReactiveProperty<int> LocaleID => _localeID;

		public LocalizationSettingsBaseModel()
        {
			_localeID.Value = 0;
        }

		public void SetLocaleID(int localeID)
        {
			_localeID.Value = localeID;
			_localeSelector.ChangeLocale(localeID);
        }
	}
}
