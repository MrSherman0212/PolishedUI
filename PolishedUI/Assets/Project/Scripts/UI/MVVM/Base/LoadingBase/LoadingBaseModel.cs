using Project.Utility;
using UniRx;

namespace Project.UI.MVVM
{
	public abstract class LoadingBaseModel
	{
		protected NewScenesManager _newScenesManager;
		protected CompositeDisposable _disposables = new();
		public ReactiveProperty<bool> CanChangeScene { get; private set; } = new() { Value = false };

		public LoadingBaseModel(NewScenesManager newScenesManager)
        {
			_newScenesManager = newScenesManager;
			_newScenesManager.CanAllowSceneChange.Subscribe(v => CanChangeScene.Value = v).AddTo(_disposables);
        }

		public virtual void ChangeScene()
        {
			_newScenesManager.SubmitSceneChange();
			UnityEngine.Debug.Log("allowed");
        }
	}
}
