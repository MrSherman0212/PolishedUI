using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine;

namespace Project 
{
	public class LocaleSelector : MonoBehaviour
	{
		private bool _canChangeLocale = true;

		public void ChangeLocale(int localeID)
        {
			if (_canChangeLocale == false && localeID > 0) return;
			StartCoroutine(SetLocale(localeID));
        }

		private IEnumerator SetLocale(int localeID)
        {
			_canChangeLocale = false;
			yield return LocalizationSettings.InitializationOperation;
			LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
			_canChangeLocale = true;
		}
	}
}
