using Project.SystemSound;
using Project.UI.MVVM;
using Project.Utility;
using Project.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Project.Zenject
{
    public class GlobalInstaller : MonoInstaller
    {
        private PageManager _pageManager;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private SystemSoundsManager _soundManager;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AssetReference _loadingScene;
        private NewScenesManager _newScenesManager;

        private LoadingDefaultModel _loadingDefaultModel;
        private LoadingDefaultViewModel _loadingDefaultViewModel;

        private LocalizationSettingsDefaultModel _localizationSettingsDefaultModel;
        private LocalizationSettingsDefaultViewModel _localizationSettingsDefaultViewModel;

        private AudioSettingsDefaultModel _audioSettingsDefaultModel;
        private AudioSettingsDefaultViewModel _audioSettingsDefaultViewModel;

        public override void InstallBindings()
        {
            // === Setup
            Container.InstantiatePrefabForComponent<Camera>(_mainCamera);

            EventSystem eventSystem = Container.InstantiatePrefabForComponent<EventSystem>(_eventSystem);
            Container.Bind<EventSystem>().FromInstance(eventSystem).AsSingle().NonLazy();

            SystemSoundsManager soundManager = Container.InstantiatePrefabForComponent<SystemSoundsManager>(_soundManager);
            Container.Bind<SystemSoundsManager>().FromInstance(soundManager).AsSingle().NonLazy();

            _pageManager = new(_eventSystem);
            Container.Bind<PageManager>().FromInstance(_pageManager).AsSingle().NonLazy();

            _newScenesManager = new(_loadingScene);
            Container.Bind<NewScenesManager>().FromInstance(_newScenesManager).AsSingle().NonLazy();

            // === MVVM
            _loadingDefaultModel = new(_newScenesManager); // --- Loading screen
            _loadingDefaultViewModel = new(_loadingDefaultModel);
            Container.Bind<LoadingDefaultViewModel>().FromInstance(_loadingDefaultViewModel).AsSingle().NonLazy();

            _localizationSettingsDefaultModel = new(); // --- Localization screen
            _localizationSettingsDefaultViewModel = new(_localizationSettingsDefaultModel);
            Container.Bind<LocalizationSettingsDefaultViewModel>().FromInstance(_localizationSettingsDefaultViewModel).AsSingle().NonLazy();

            _audioSettingsDefaultModel = new(_audioMixer); // --- AudioSettings screen
            _audioSettingsDefaultViewModel = new(_audioSettingsDefaultModel);
            Container.Bind<AudioSettingsDefaultViewModel>().FromInstance(_audioSettingsDefaultViewModel).AsSingle().NonLazy();
        }
    }
}
 