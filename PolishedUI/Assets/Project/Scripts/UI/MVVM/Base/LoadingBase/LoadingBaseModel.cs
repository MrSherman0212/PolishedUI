using Project.Utility;
using UniRx;

namespace Project.UI.MVVM
{
	public abstract class LoadingBaseModel
	{
		protected SceneLoader _sceneLoader;
		protected CompositeDisposable _disposables = new();
		public ReactiveProperty<bool> CanChangeScene { get; private set; } = new() { Value = false };

		public LoadingBaseModel(SceneLoader sceneLoader)
        {
			_sceneLoader = sceneLoader;
			_sceneLoader.CanChangeScene.Subscribe(v => CanChangeScene.Value = v).AddTo(_disposables);
        }

		public virtual void ChangeScene()
        {
			_sceneLoader.AllowLoadScene();
        }
	}
}
