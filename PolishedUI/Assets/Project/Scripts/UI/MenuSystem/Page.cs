using UnityEngine;
using Cinemachine;

namespace Project.UI
{
    public class Page : MonoBehaviour
    {
        private CinemachineVirtualCamera _camera;

        public bool ExitOnPagePush = false;

        private void Awake()
        {
            _camera = GetComponentInChildren<CinemachineVirtualCamera>();
            _camera.gameObject.SetActive(false);
        }

        public void OnEnter(bool playAudio)
        {
            _camera.gameObject.SetActive(true);
        }

        public void OnExit(bool playAudio)
        {
            _camera.gameObject.SetActive(false);
        }
    }
}
