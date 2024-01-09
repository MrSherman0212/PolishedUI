using System.Collections.Generic;

namespace Project.UI 
{
	public class PageManager
	{
		private List<BasePage> _pageStack = new List<BasePage>();
		private BasePage _currentPage => _pageStack[_pageStack.Count];

		public void PushPage(BasePage page)
        {
			_pageStack.Add(page);
        }

		public void PopPage()
		{
			if (_pageStack.Count == 1) return;
			_currentPage.ExitPage();
			_pageStack.Remove(_currentPage);
			_currentPage.EnterPage();
		}
	}
}
