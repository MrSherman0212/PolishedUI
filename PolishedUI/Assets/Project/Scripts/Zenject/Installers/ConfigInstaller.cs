using Project.Game.Configs;
using Project.Sound.Configs;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private SOHeroConfig _heroConfig;
        [SerializeField] private SOSystemSoundsConfig _UISoundConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_heroConfig);
            Container.BindInstance(_UISoundConfig);
        }
    }
}
