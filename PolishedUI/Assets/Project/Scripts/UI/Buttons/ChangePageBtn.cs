using Project.SystemSound;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.UI
{
    public class ChangePageBtn : BaseButton
    {
        private BasePage _currentPage;
        [SerializeField] private BasePage _nextPage;

        protected override void Init(SystemSoundsManager soundsManager)
        {
            base.Init(soundsManager);
            _currentPage = GetComponentInParent<BasePage>();
        }

        protected override void OnClick(BaseEventData eventData)
        {
            base.OnClick(eventData);
            _currentPage.ChangePage(_nextPage);
        }
    }
}
