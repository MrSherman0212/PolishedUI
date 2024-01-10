
namespace Project.UI.MVVM
{
	public abstract class LocalizationSettingsBaseViewModel
	{
		protected LocalizationSettingsBaseModel _model;

		public LocalizationSettingsBaseViewModel(LocalizationSettingsBaseModel model)
        {
			_model = model;
        }
	}
}
