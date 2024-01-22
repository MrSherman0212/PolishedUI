using UnityEngine;
using Zenject;
using UniRx;

namespace Project.UI.MVVM
{
	public class LoadingDefaultView : LoadingBaseView
	{
		[SerializeField] private BaseButton _changeSceneBtn;

		[Inject]
	 	private void Construct(LoadingDefaultViewModel viewModel)
        {
			Init(viewModel);
            _changeSceneBtn.OnTriggerBtn.Subscribe(v => ChangeScene()).AddTo(_disposables);
        }

        protected override void Display(bool v)
        {
            _changeSceneBtn.gameObject.SetActive(v);
        }
    }
}
