using UnityEngine.EventSystems;
using UnityEngine;
using Zenject;

namespace Project.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BasePage : MonoBehaviour
    {
        protected PageManager _pageManager;
        protected CanvasGroup _canvasGroup;
        protected EventSystem _eventSystem;
        [SerializeField] protected GameObject _firstSelectedUIElement;

        [Inject]
        protected virtual void Init(PageManager pageManager, EventSystem eventSystem)
        {
            _pageManager = pageManager;
            _canvasGroup = GetComponent<CanvasGroup>();
            _eventSystem = eventSystem;
        }

        protected virtual void ChangePageState(bool v)
        {
            _canvasGroup.interactable = v;
            _canvasGroup.blocksRaycasts = v;
        }

        protected virtual void SetFirstSelectedUIElement()
        {
            if (_firstSelectedUIElement != null)
                _eventSystem.SetSelectedGameObject(_firstSelectedUIElement);
        }

        public virtual void ExitPage()
        {
            ChangePageState(false);
        }

        public virtual void EnterPage()
        {
            ChangePageState(true);
            _pageManager.PushPage(this);
            SetFirstSelectedUIElement();
        }

        public virtual void ChangePage(BasePage nextPage)
        {
            if (this == nextPage) return;
            ExitPage();
            nextPage.EnterPage();
        }
    }
}
