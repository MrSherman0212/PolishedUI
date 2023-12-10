using Project.Sound;
using Project.UI;
using Zenject;
using UnityEngine;

namespace Project.Zenject
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private SystemSoundsManager _soundManager;

        public override void InstallBindings()
        {
            SystemSoundsManager soundManager = Container.InstantiatePrefabForComponent<SystemSoundsManager>(_soundManager, transform.position, Quaternion.identity, null);
            Container.BindInterfacesAndSelfTo<SystemSoundsManager>().FromInstance(soundManager).AsSingle().NonLazy();
        }
    }
}
