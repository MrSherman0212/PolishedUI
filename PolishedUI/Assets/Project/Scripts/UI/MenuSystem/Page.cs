using UnityEngine;
using Cinemachine;

namespace Project.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class Page : MonoBehaviour
    {
        private AudioSource _audioSource;
        private CinemachineVirtualCamera _camera;

        [SerializeField] private AudioClip _entrySound;
        [SerializeField] private AudioClip _exitSound;

        public bool ExitOnPagePush = false;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _camera = GetComponentInChildren<CinemachineVirtualCamera>();

            _audioSource.playOnAwake = false;
            _audioSource.loop = false;
            _audioSource.spatialBlend = 0;
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
