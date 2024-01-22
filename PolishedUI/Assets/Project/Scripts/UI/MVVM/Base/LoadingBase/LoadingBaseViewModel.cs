using Zenject;
using UniRx;

namespace Project.UI.MVVM
{
	public abstract class LoadingBaseViewModel
	{
		protected LoadingBaseModel _model;
		protected CompositeDisposable _disposables = new();
		public ReactiveProperty<bool> CanChangeSceneView { get; private set; } = new() { Value = false };

		[Inject]
		public LoadingBaseViewModel(LoadingBaseModel model)
        {
			_model = model;
			_model.CanChangeScene.Subscribe(v => CanChangeSceneView.Value = v).AddTo(_disposables);
        }

		public void ChangeSceneView()
        {
			_model.ChangeScene();
        }
	}
}
