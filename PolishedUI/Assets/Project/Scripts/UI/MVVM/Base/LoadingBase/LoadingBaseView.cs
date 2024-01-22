using UnityEngine;
using UniRx;

namespace Project.UI.MVVM
{
	public abstract class LoadingBaseView : MonoBehaviour
	{
		protected LoadingBaseViewModel _viewModel;
		protected CompositeDisposable _disposables = new();
		
	 	protected virtual void Init(LoadingBaseViewModel viewModel)
        {
			_viewModel = viewModel;
			_viewModel.CanChangeSceneView.Subscribe(v => Display(v)).AddTo(_disposables);
        }

		protected virtual void ChangeScene()
        {
			_viewModel.ChangeSceneView();
        }

		protected abstract void Display(bool v);
	}
}
