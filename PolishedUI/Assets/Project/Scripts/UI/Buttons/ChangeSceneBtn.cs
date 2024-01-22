using Project.Utility;
using UnityEngine.EventSystems;
using UnityEngine;
using Zenject;

namespace Project.UI
{
    public class ChangeSceneBtn : BaseButton
    {
        private SceneLoader _sceneLoader;
        [SerializeField] private string _sceneName;

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        protected override void OnClick(BaseEventData eventData)
        {
            base.OnClick(eventData);
            _sceneLoader.ChangeScene(_sceneName);
        }
    }
}
