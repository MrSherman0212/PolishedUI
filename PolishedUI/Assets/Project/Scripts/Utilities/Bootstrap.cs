using Project.UI;
using UnityEngine;

namespace Project.Utility
{
	public class Bootstrap : MonoBehaviour
	{
        [SerializeField] private BasePage _entryPage;

        private void Start()
        {
            _entryPage.EnterPage();
        }
    }
}
