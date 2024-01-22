using Project.Utility;

namespace Project.UI.MVVM
{
	public class LoadingDefaultModel : LoadingBaseModel
	{
		public LoadingDefaultModel(SceneLoader sceneLoader) : base(sceneLoader)
        {
			_sceneLoader = sceneLoader;
        }
	}
}
