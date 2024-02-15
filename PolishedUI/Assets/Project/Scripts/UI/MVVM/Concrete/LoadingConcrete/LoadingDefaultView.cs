using UnityEngine;
using Zenject;
using UniRx;

namespace Project.UI.MVVM
{
	public class LoadingDefaultView : LoadingBaseView
	{
		[SerializeField] private BaseButton _submitSceneChangeBtn;

		[Inject]
	 	private void Construct(LoadingDefaultViewModel viewModel)
        {
			Init(viewModel);
            _submitSceneChangeBtn.OnTriggerBtn.Subscribe(v => ChangeScene()).AddTo(_disposables);
        }

        protected override void Display(bool v)
        {
            if (_submitSceneChangeBtn != null)
               _submitSceneChangeBtn.gameObject.SetActive(v);
        }
    }
}
