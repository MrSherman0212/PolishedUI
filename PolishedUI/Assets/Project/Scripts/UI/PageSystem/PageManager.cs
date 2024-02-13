using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine;

namespace Project.UI 
{
	public sealed class PageManager
	{
		private EventSystem _eventSystem;
		private List<BasePage> _pageStack = new();
		private Dictionary<BasePage, GameObject> _selectedObjects = new();
        private BasePage _currentPage => _pageStack.LastOrDefault();

		public PageManager(EventSystem eventSystem)
        {
			_eventSystem = eventSystem;
		}

		private void ClearSelectedObjects(int i)
        {
			for (int j = i; j < _pageStack.Count; j++)
                _selectedObjects.Remove(_pageStack[j]);
        }

		public void PushPage(BasePage page)
        {
			bool isDuplicate = false;
            for (int i = 0; i < _pageStack.Count; i++)
            {
				if (_pageStack[i] != page) continue;
				isDuplicate = true;
				int nextPageIndex = i + 1;
				ClearSelectedObjects(nextPageIndex);
				_pageStack.RemoveRange(nextPageIndex, _pageStack.Count - nextPageIndex);
				_eventSystem.SetSelectedGameObject(_selectedObjects[_currentPage]);
			}
			if (!isDuplicate)
				_pageStack.Add(page);
        }

		public void SetLastSelectedUIElement(GameObject lastSelectedUIObject)
        {
			if (_selectedObjects.ContainsKey(_currentPage))
				_selectedObjects[_currentPage] = lastSelectedUIObject;
			else
				_selectedObjects.Add(_currentPage, lastSelectedUIObject);
		}

        public void ClearAll()
        {
			_pageStack.Clear();
			_selectedObjects.Clear();
        }
    }
}
