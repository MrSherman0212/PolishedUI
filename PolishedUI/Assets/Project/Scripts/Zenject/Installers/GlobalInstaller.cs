using Project.SystemSound;
using Project.UI.MVVM;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private SystemSoundsManager _soundManager;

        private LocalizationSettingsDefaultModel _localizationSettingsDefaultModel;
        private LocalizationSettingsDefaultViewModel _localizationSettingsDefaultViewModel;

        public override void InstallBindings()
        {
            SystemSoundsManager soundManager = Container.InstantiatePrefabForComponent<SystemSoundsManager>(_soundManager);
            Container.Bind<SystemSoundsManager>().FromInstance(soundManager).AsSingle().NonLazy();

            _localizationSettingsDefaultModel = new();
            _localizationSettingsDefaultViewModel = new(_localizationSettingsDefaultModel);
            Container.Bind<LocalizationSettingsDefaultViewModel>().FromInstance(_localizationSettingsDefaultViewModel).AsSingle().NonLazy();
        }
    }
}
 