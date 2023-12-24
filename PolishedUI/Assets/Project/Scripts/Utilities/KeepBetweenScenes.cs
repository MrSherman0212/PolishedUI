using UnityEngine;

namespace Project.Utility
{
    public class KeepBetweenScenes : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
