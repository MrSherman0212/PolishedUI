using Zenject;

namespace Project.UI.MVVM
{
	public class LoadingDefaultViewModel : LoadingBaseViewModel
	{
		public LoadingDefaultViewModel(LoadingBaseModel model) : base(model)
        {
			_model = model;
        }
	}
}
