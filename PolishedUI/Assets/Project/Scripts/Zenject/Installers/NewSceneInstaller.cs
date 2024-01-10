using UnityEngine.EventSystems;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class NewSceneInstaller : MonoInstaller
    {
        [SerializeField] private EventSystem _eventSystem;

        public override void InstallBindings()
        {
            Container.Bind<EventSystem>().FromInstance(_eventSystem).AsSingle().NonLazy();
        }
    }
}
