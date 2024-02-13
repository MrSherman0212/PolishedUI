using Project.Utility;
using UnityEngine.EventSystems;
using UnityEngine;
using Zenject;

namespace Project.UI
{
    public class ChangeSceneBtn : BaseButton
    {
        private NewScenesManager _sceneLoader;
        private PageManager _pageManager;
        [SerializeField] private string _sceneName;

        [Inject]
        public void Construct(NewScenesManager sceneLoader, PageManager pageManager)
        {
            _sceneLoader = sceneLoader;
            _pageManager = pageManager;
        }

        protected override void OnClick(BaseEventData eventData)
        {
            base.OnClick(eventData);
            _sceneLoader.ChangeScene(_sceneName);
            _pageManager.ClearAll();
        }
    }
}
