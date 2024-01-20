using UnityEngine.Audio;
using UnityEngine;
using UniRx;

namespace Project.UI.MVVM
{
	public abstract class AudioSettingsBaseModel
	{
		protected AudioMixer _audioMixer;
		public ReactiveProperty<float> MasterVolume { get; protected set; } = new();

		public AudioSettingsBaseModel(AudioMixer mixer)
        {
			_audioMixer = mixer;
        }

		public void SetMasterVolume(float v)
        {
			MasterVolume.Value = v;
			//_audioMixer.SetFloat("MasterVolume", Mathf.Log10(v) * 20);
			_audioMixer.SetFloat("MasterVolume", Mathf.Max(19.9316f * Mathf.Log(v), -80f));

		}
	}
}
