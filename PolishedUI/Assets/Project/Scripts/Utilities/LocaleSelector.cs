using UnityEngine.Localization.Settings;

namespace Project.Utility
{
	public class LocaleSelector
	{
		private bool _canChangeLocale = true;

        public void ChangeLocale(int localeID)
        {
			if (_canChangeLocale == false && localeID < 0) return;
			SetLocale(localeID);
        }

		private async void SetLocale(int localeID)
        {
			_canChangeLocale = false;
			await LocalizationSettings.InitializationOperation.Task;
			LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
			_canChangeLocale = true;
		}
	}
}
