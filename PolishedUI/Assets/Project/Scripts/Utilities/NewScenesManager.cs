using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UniRx;

namespace Project.Utility
{
	public class NewScenesManager
	{
		private SceneInstance _loadingSceneInstance;
		private SceneInstance _loadedSceneInstance;

		private AssetReference _loadingSceneAsset;
		private bool _canUnloadScene = false;

		public ReactiveProperty<bool> CanAllowSceneChange { get; private set; } = new() { Value = false };

		public NewScenesManager(AssetReference loadingScene)
        {
			_loadingSceneAsset = loadingScene;
        }

		private void LoadNextScene(AssetReference nextSceneAsset, bool isInitScene)
		{
			Addressables.LoadSceneAsync(nextSceneAsset, LoadSceneMode.Additive, false).Completed += handle =>
			{
				_loadedSceneInstance = handle.Result;
				CanAllowSceneChange.Value = true;
				if (isInitScene)
					_loadedSceneInstance.ActivateAsync();
			};
		}

		private void ShowLoadingScreen(AssetReference nextSceneAsset, bool isInitScene)
        {
			Addressables.LoadSceneAsync(_loadingSceneAsset).Completed += handle =>
			{
				_loadingSceneInstance = handle.Result;
				_canUnloadScene = true;
				if (!isInitScene)
					UnloadPreviousScene(_loadingSceneInstance);
				LoadNextScene(nextSceneAsset, isInitScene);
			};
		}

        private void UnloadPreviousScene(SceneInstance sceneToUnload)
        {
			if (_canUnloadScene)
            {
				Addressables.UnloadSceneAsync(sceneToUnload);
				_canUnloadScene = false;
            }
        }

        public void ChangeScene(AssetReference nextSceneAsset, bool isInitScene = false)
        {
			CanAllowSceneChange.Value = false;
			if (!isInitScene)
				ShowLoadingScreen(nextSceneAsset, isInitScene);
			else
				LoadNextScene(nextSceneAsset, isInitScene);
        }

		public void SubmitSceneChange()
        {
			if (!CanAllowSceneChange.Value) return;
			_loadedSceneInstance.ActivateAsync().completed += handle =>
			{
				Addressables.UnloadSceneAsync(_loadingSceneInstance);
			};
        }
    }
}
