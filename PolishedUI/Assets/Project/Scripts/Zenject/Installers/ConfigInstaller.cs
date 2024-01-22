using Project.Game.Configs;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private SceneNamesConfig _sceneNamesConfig;

        public override void InstallBindings()
        {
            Container.Bind<SceneNamesConfig>().FromInstance(_sceneNamesConfig);
        }
    }
}
