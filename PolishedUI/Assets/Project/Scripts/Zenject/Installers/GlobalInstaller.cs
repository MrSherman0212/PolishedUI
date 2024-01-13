using Project.SystemSound;
using Project.UI.MVVM;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private SystemSoundsManager _soundManager;
        [SerializeField] private LocaleSelector _localeSelector;

        //private LocalizationSettingsDefaultModel _localizationSettingsDefaultModel;
        //private LocalizationSettingsDefaultViewModel _localizationSettingsDefaultViewModel;

        public override void InstallBindings()
        {
            SystemSoundsManager soundManager = Container.InstantiatePrefabForComponent<SystemSoundsManager>(_soundManager);
            Container.Bind<SystemSoundsManager>().FromInstance(soundManager).AsSingle().NonLazy();

            LocaleSelector localeSelector = Container.InstantiatePrefabForComponent<LocaleSelector>(_localeSelector);
            Container.Bind<LocaleSelector>().FromInstance(localeSelector).AsSingle().NonLazy();

            //_localizationSettingsDefaultModel = new(_localeSelector);
            //_localizationSettingsDefaultViewModel = new(_localizationSettingsDefaultModel);
            //Container.Bind<LocalizationSettingsDefaultModel>().FromInstance(_localizationSettingsDefaultModel).AsSingle();
            //Container.Bind<LocalizationSettingsDefaultViewModel>().FromInstance(_localizationSettingsDefaultViewModel).AsSingle();
        }
    }
}
 