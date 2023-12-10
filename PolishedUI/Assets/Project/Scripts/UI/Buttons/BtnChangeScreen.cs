using Project.Sound;
using UnityEngine;
using Zenject;

namespace Project.UI.Buttons
{
    public class BtnChangeScreen : BaseButton
    {
        [Inject] private SystemSoundsManager _systemSoundsManager;

        public override void OnClick()
        {
            _systemSoundsManager.SystemSoundsPoolRef.Get();
        }
    }
}
