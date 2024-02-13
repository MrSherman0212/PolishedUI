using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UniRx;

namespace Project.Utility
{
	public class NewScenesManager
	{
		private SceneInstance _previousLoadedSceneInstance;
		private SceneInstance _currentLoadedSceneInstance;

		private SceneInstance _loadingSceneInstance;
		private AssetReference _loadingScene;
		private bool _canUnloadScene = false;

		public ReactiveProperty<bool> CanChangeScene { get; private set; } = new() { Value = false };

		public NewScenesManager(AssetReference loadingScene)
        {
			_loadingScene = loadingScene;
        }

		private void LoadNewScene(string sceneName)
		{
			Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Additive, false).Completed += handle =>
			{
				_currentLoadedSceneInstance = handle.Result;
				CanChangeScene.Value = true;
				_canUnloadScene = true;
			};
			_previousLoadedSceneInstance = _currentLoadedSceneInstance;
		}

		private void ShowLoadingScreen()
        {
			Addressables.LoadSceneAsync(_loadingScene).Completed += handle =>
			{
				_loadingSceneInstance = handle.Result;
                if (_canUnloadScene)
					UnloadPreviousScene();
			};
		}

        private void UnloadPreviousScene()
			=> Addressables.UnloadSceneAsync(_previousLoadedSceneInstance);

        public void ChangeScene(string sceneName, bool isInitScene = false)
        {
			CanChangeScene.Value = false;
            if (!isInitScene)
				ShowLoadingScreen();
			LoadNewScene(sceneName);
        }

		public void SubmitSceneChange()
        {
			if (!CanChangeScene.Value) return;
			_currentLoadedSceneInstance.ActivateAsync();
			Addressables.UnloadSceneAsync(_loadingSceneInstance);
        }
    }
}
