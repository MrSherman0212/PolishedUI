using UnityEngine;
using Zenject;

namespace Project.Utility
{
	public class Bootstrap : MonoBehaviour
	{
        private NewScenesManager _newScenesManager;

        [Inject]
        private void Init(NewScenesManager newScenesManager)
        {
            _newScenesManager = newScenesManager;
        }

        private void Start()
        {
            _newScenesManager.ChangeScene("MainMenu");
        }
    }
}
