using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Zenject;
using UniRx;

namespace Project.UI.MVVM
{
	public class LocalizationSettingsDefaultView : LocalizationSettingsBaseView
	{
        [SerializeField] private TMP_Dropdown _localizationDropDown;
        [SerializeField] List<string> localeNames = new();
        [SerializeField] private BaseButton _submit;
        [SerializeField] private BaseButton _cancel;

        [Inject]
        private void Construct(LocalizationSettingsDefaultViewModel viewModel)
        {
            Init(viewModel);
            UpdateLocaleNames();
        }

        private async Task InitLocalizationOperation()
        {
            await LocalizationSettings.InitializationOperation.Task;
            foreach (var item in LocalizationSettings.AvailableLocales.Locales)
                localeNames.Add(item.LocaleName);
        }

        private async void UpdateLocaleNames()
        {
            await InitLocalizationOperation();
            _localizationDropDown.ClearOptions();
            _localizationDropDown.AddOptions(localeNames);
        }

        protected override void Init(LocalizationSettingsBaseViewModel viewModel)
        {
            base.Init(viewModel);
            _submit.OnTriggerBtn.Subscribe(v => { _viewModel.SubmitLocaleID(); }).AddTo(_disposables);
            _cancel.OnTriggerBtn.Subscribe(v => { _viewModel.ResetLocaleID(); }).AddTo(_disposables);
            _localizationDropDown.onValueChanged.AddListener(SetLocaleID);
            _localizationDropDown.ClearOptions();
        }

        protected override void SetLocaleID(int v)
        {
            _viewModel.SetLocaleID(v);
        }

        protected override void DisplayLocales()
        {
            _localizationDropDown.value = _viewModel.LocaleIDView.Value;
        }
    }
}
