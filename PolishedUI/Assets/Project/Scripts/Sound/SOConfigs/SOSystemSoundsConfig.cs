using UnityEngine;

namespace Project.Sound.Configs
{
    [CreateAssetMenu(fileName = "NewUISoundConfig", menuName = "Configs/Sound/NewUISoundConfig")]
    public class SOSystemSoundsConfig : ScriptableObject
    {
        [SerializeField] private AudioClip _chooseSND;
        [SerializeField] private AudioClip _confirmSND;
        [SerializeField] private AudioClip _cancelSND;

        public AudioClip ChooseSND => _chooseSND;
        public AudioClip ConfirmSND => _confirmSND;
        public AudioClip CancelSND => _cancelSND;
    }
}
