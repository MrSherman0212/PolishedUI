using Project.Game.Configs;
using UnityEngine.SceneManagement;
using UniRx;

namespace Project.Utility
{
	public class SceneLoader
	{
		private string _loadingSceneName;
		public ReactiveProperty<bool> CanChangeScene { get; private set; } = new() { Value = false };

        public SceneLoader(SceneNamesConfig sceneNamesConfig)
			=> _loadingSceneName = sceneNamesConfig.LoadingSceneName;

        private void UnloadScene(string sceneName)
			=> SceneManager.UnloadSceneAsync(sceneName);

        public void ChangeScene(string sceneName)
        {
			CanChangeScene.Value = false;
			SceneManager.LoadSceneAsync(_loadingSceneName);
			SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            CanChangeScene.Value = true;
        }

		public void AllowLoadScene()
        {
			if (!CanChangeScene.Value) return;
			UnloadScene(_loadingSceneName);
        }
	}
}
