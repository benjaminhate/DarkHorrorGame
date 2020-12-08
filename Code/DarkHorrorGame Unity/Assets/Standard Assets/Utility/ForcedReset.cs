using Standard_Assets.CrossPlatformInput.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Standard_Assets.Utility
{
    [RequireComponent(typeof (Image))]
    public class ForcedReset : MonoBehaviour
    {
        private void Update()
        {
            // if we have forced a reset ...
            if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
            {
                //... reload the scene
                Application.LoadLevelAsync(Application.loadedLevelName);
            }
        }
    }
}
