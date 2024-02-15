using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using Zenject;

namespace Project.Utility
{
    public class InitGame : MonoBehaviour
    {
        private NewScenesManager _newScenesManager;

        private SceneInstance _initSceneInstance;
        [SerializeField] private AssetReference _initSceneAsset;
        [SerializeField] private AssetReference _mainMenuSceneAsset;

        [Inject]
        private void Init(NewScenesManager newScenesManager)
        {
            _newScenesManager = newScenesManager;
        }

        private void Start()
        {
            Addressables.LoadSceneAsync(_initSceneAsset).Completed += handle =>
            {
                _initSceneInstance = handle.Result;
            };
            _newScenesManager.ChangeScene(_mainMenuSceneAsset, true);
            Debug.Log("Unload InitScene");
        }
    }
}
