using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject mainMenuUICanvas;
        [SerializeField] GameObject playUICanvas;

        public void ToggleMainMenuUI(bool isActive)
        {
            Debug.Log("main menu control");
            mainMenuUICanvas.SetActive(isActive);
        }

        public void TogglePlayUI(bool isActive)
        {
            playUICanvas.SetActive(isActive);
        }

    }
}

