using UnityEngine;
using Zenject;

namespace Project.Utility
{
    public class InitGame : MonoBehaviour
    {
        private NewScenesManager _scenesManager;
        [SerializeField] private string _mainMenuScene;

        [Inject]
        private void Init(NewScenesManager scenesManager)
        {
            _scenesManager = scenesManager;
        }

        private void Start()
        {
            _scenesManager.ChangeScene(_mainMenuScene, true);
        }
    }
}
