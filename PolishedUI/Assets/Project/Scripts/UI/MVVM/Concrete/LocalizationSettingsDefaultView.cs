using UnityEngine.UI;
using UnityEngine;
using UniRx;

namespace Project.UI.MVVM
{
	public class LocalizationSettingsDefaultView : LocalizationSettingsBaseView
	{
        [SerializeField] private Dropdown _localizationDropDown;
        [SerializeField] private BaseButton _submit;
        [SerializeField] private BaseButton _cancel;

        protected override void Init(LocalizationSettingsBaseViewModel viewModel)
        {
            base.Init(viewModel);
            _submit.OnTriggerBtn.Subscribe(v => { _viewModel.SubmitLocaleID(); }).AddTo(_disposables);
            _cancel.OnTriggerBtn.Subscribe(v => { _viewModel.ResetLocaleID(); }).AddTo(_disposables);
        }

        protected override void SetLocaleID()
        {
            
        }

        protected override void DisplayLocales()
        {
            
        }
    }
}
