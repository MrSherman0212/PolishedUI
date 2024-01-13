using Project.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class NewSceneInstaller : MonoInstaller
    {
        private PageManager _pageManager;
        [SerializeField] private EventSystem _eventSystem;

        public override void InstallBindings()
        {
            Container.Bind<EventSystem>().FromInstance(_eventSystem).AsSingle().NonLazy();
            _pageManager = new(_eventSystem);
            Container.Bind<PageManager>().FromInstance(_pageManager).AsSingle().NonLazy();
        }
    }
}
