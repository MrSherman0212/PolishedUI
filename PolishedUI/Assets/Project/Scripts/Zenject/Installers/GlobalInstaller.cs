using Project.SystemSound;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private SystemSoundsManager _soundManager;

        public override void InstallBindings()
        {
            SystemSoundsManager soundManager = Container.InstantiatePrefabForComponent<SystemSoundsManager>(_soundManager);
            Container.Bind<SystemSoundsManager>().FromInstance(soundManager).AsSingle();
        }
    }
}
 