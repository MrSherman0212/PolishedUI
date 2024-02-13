using Project.Utility;

namespace Project.UI.MVVM
{
	public class LoadingDefaultModel : LoadingBaseModel
	{
		public LoadingDefaultModel(NewScenesManager newScenesManager) : base(newScenesManager)
        {
			_sceneLoader = newScenesManager;
        }
	}
}
