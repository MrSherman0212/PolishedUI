using Project.Game.Configs;
using Project.SystemSound;
using Project.UI.MVVM;
using Project.Utility;
using Project.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine;
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
        private SceneLoader _sceneLoader;

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


            SceneNamesConfig sceneNamesConfig = Container.Resolve<SceneNamesConfig>();
            _sceneLoader = new(sceneNamesConfig);
            Container.Bind<SceneLoader>().FromInstance(_sceneLoader).AsSingle().NonLazy();

            // === MVVM
            _loadingDefaultModel = new(_sceneLoader);
            _loadingDefaultViewModel = new(_loadingDefaultModel);
            Container.Bind<LoadingDefaultViewModel>().FromInstance(_loadingDefaultViewModel).AsSingle().NonLazy();

            _localizationSettingsDefaultModel = new();
            _localizationSettingsDefaultViewModel = new(_localizationSettingsDefaultModel);
            Container.Bind<LocalizationSettingsDefaultViewModel>().FromInstance(_localizationSettingsDefaultViewModel).AsSingle().NonLazy();

            _audioSettingsDefaultModel = new(_audioMixer);
            _audioSettingsDefaultViewModel = new(_audioSettingsDefaultModel);
            Container.Bind<AudioSettingsDefaultViewModel>().FromInstance(_audioSettingsDefaultViewModel).AsSingle().NonLazy();
        }
    }
}
 