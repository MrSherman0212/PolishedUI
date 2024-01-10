using Project.UI;
using UnityEngine;

namespace Project.Utility
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private BasePage _entryPage;

		private void Awake()
        {
			_entryPage.EnterPage();
        }
	}
}
