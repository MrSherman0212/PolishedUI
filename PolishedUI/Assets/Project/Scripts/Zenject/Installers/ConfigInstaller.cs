using Project.Game.Configs;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private HeroConfig _heroConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_heroConfig);
        }
    }
}
