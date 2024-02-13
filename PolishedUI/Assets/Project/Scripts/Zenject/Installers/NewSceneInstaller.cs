using Project.Utility;
using Project.UI;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class NewSceneInstaller : MonoInstaller
    {
        private NewScenesManager _localeSelector;
        [SerializeField] private BasePage _entryPage;

        public override void InstallBindings()
        {
            _localeSelector = Container.Resolve<NewScenesManager>();
            _localeSelector.SetEntryPage(_entryPage);
        }
    }
}
