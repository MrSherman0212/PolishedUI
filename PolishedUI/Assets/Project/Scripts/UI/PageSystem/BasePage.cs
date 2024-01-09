using UnityEngine;
using Zenject;

namespace Project.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BasePage : MonoBehaviour
    {
        protected PageManager _pageManager;
        protected CanvasGroup _canvasGroup;

        [Inject]
        protected virtual void Init(PageManager pageManager)
        {
            _pageManager = pageManager;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        protected virtual void ChangePageState(bool v)
        {
            _canvasGroup.interactable = v;
            _canvasGroup.blocksRaycasts = v;
        }

        public virtual void ExitPage()
        {
            ChangePageState(false);
        }

        public virtual void EnterPage()
        {
            ChangePageState(true);
            _pageManager.PushPage(this);
        }

        public virtual void ChangePage(BasePage nextPage)
        {
            if (this == nextPage) return;
            ExitPage();
            nextPage.EnterPage();
        }
    }
}
