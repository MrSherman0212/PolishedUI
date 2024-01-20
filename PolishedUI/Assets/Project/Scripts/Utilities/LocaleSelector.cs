using UnityEngine.Localization.Settings;
using System.Threading.Tasks;

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

		private async Task InitLocaleOperation()
        {
			await LocalizationSettings.InitializationOperation.Task;
        }

		private async void SetLocale(int localeID)
        {
			_canChangeLocale = false;
			await InitLocaleOperation();
			LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
			_canChangeLocale = true;
		}
	}
}
