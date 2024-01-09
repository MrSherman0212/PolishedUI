using Cinemachine;

namespace Project.UI
{
	public class InWorldPage : BasePage
	{
		private CinemachineVirtualCamera _camera;

		protected override void Init(PageManager pageManager)
        {
			base.Init(pageManager);
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
