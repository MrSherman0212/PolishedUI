using UnityEngine;

namespace Project.Game.Configs
{
	[CreateAssetMenu(fileName = "NewSceneNamesConfig", menuName = "Configs/Game/NewSceneNamesConfig")]
	public class SceneNamesConfig : ScriptableObject
	{
		[field: SerializeField] public string LoadingSceneName { get; private set; }
	}
}
