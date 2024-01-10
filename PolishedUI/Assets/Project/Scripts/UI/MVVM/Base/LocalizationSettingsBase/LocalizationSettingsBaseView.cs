using UnityEngine;

namespace Project.UI.MVVM
{
	public abstract class LocalizationSettingsBaseView : MonoBehaviour
	{
		protected LocalizationSettingsBaseViewModel _viewModel;

		private void Init(LocalizationSettingsBaseViewModel viewModel)
        {
			_viewModel = viewModel;
        }
	}
}
