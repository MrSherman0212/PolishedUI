using UnityEngine;

namespace Project.UI
{
	public class InCameraPage : BasePage
	{
		protected override void Init(PageManager pageManager)
		{
			base.Init(pageManager);
			ExitPage();
		}

		protected override void ChangePageState(bool v)
		{
			base.ChangePageState(v);
            if (v)
				_canvasGroup.alpha = 1;
			else
				_canvasGroup.alpha = 0;
		}
	}
}
