using UnityEngine.EventSystems;
using Cinemachine;

namespace Project.UI
{
	public class InWorldPage : BasePage
	{
		private CinemachineVirtualCamera _camera;

		protected override void Init(PageManager pageManager, EventSystem eventSystem)
        {
			base.Init(pageManager, eventSystem);
			_camera = GetComponentInChildren<CinemachineVirtualCamera>();
			ExitPage();
		}

		protected override void ChangePageState(bool v)
        {
			base.ChangePageState(v);
			_camera.gameObject.SetActive(v);
        }
	}
}
