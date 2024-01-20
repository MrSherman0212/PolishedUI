using Project.SystemSound;
using Project.UI.MVVM;
using UnityEngine.Audio;
using UnityEngine;
using Zenject;

namespace Project.Zenject
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private SystemSoundsManager _soundManager;
        [SerializeField] private AudioMixer _audioMixer;

        private LocalizationSettingsDefaultModel _localizationSettingsDefaultModel;
        private LocalizationSettingsDefaultViewModel _localizationSettingsDefaultViewModel;

        private AudioSettingsDefaultModel _audioSettingsDefaultModel;
        private AudioSettingsDefaultViewModel _audioSettingsDefaultViewModel;

        public override void InstallBindings()
        {
            SystemSoundsManager soundManager = Container.InstantiatePrefabForComponent<SystemSoundsManager>(_soundManager);
            Container.Bind<SystemSoundsManager>().FromInstance(soundManager).AsSingle().NonLazy();

            _localizationSettingsDefaultModel = new();
            _localizationSettingsDefaultViewModel = new(_localizationSettingsDefaultModel);
            Container.Bind<LocalizationSettingsDefaultViewModel>().FromInstance(_localizationSettingsDefaultViewModel).AsSingle().NonLazy();

            _audioSettingsDefaultModel = new(_audioMixer);
            _audioSettingsDefaultViewModel = new(_audioSettingsDefaultModel);
            Container.Bind<AudioSettingsDefaultViewModel>().FromInstance(_audioSettingsDefaultViewModel).AsSingle().NonLazy();
        }
    }
}
 