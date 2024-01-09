using UnityEngine;

namespace Project.SystemSound
{
    [CreateAssetMenu(fileName = "NewBtnSounds", menuName = "Configs/Sound/BtnSounds")]
    public class BtnSoundsConfig : ScriptableObject
    {
        [SerializeField] private AudioClip _selectSound;
        [SerializeField] private AudioClip _unselectSound;
        [SerializeField] private AudioClip _submitSound;

        public AudioClip SelectSound => _selectSound;
        public AudioClip DeselectSound => _unselectSound;
        public AudioClip SubmitSound => _submitSound;
    }
}
