using Project.SystemSound;
using Project.UI;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private SystemSoundsManager _soundManager;
        private PageManager _pageManager = new();

        public override void InstallBindings()
        {
            SystemSoundsManager soundManager = Container.InstantiatePrefabForComponent<SystemSoundsManager>(_soundManager);
            Container.Bind<SystemSoundsManager>().FromInstance(soundManager).AsSingle();
            Container.Bind<PageManager>().FromInstance(_pageManager).AsSingle();
        }
    }
}
 