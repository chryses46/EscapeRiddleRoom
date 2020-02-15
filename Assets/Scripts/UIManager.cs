using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Canvas mainMenuUICanvas;
        [SerializeField] Canvas playUICanvas;

        public void ToggleMainMenuUI(bool isActive)
        {
            mainMenuUICanvas.gameObject.SetActive(isActive);
        }

        public void TogglePlayUI(bool isActive)
        {
            playUICanvas.gameObject.SetActive(isActive);
        }

    }
}

