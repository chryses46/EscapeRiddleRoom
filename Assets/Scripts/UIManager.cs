using System;
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
        [SerializeField] GameObject pauseInventoryScreen;
        [SerializeField] GameObject timer;
        [SerializeField] GameObject riddlePopUp;
        [SerializeField] Image riddleImage;
        [SerializeField] GameObject gameOverUICanvas;

        public void ToggleMainMenuUI(bool isActive)
        {
            mainMenuUICanvas.SetActive(isActive);
        }

        public void TogglePlayUI(bool isActive)
        {
            playUICanvas.SetActive(isActive);
        }

        public void TogglePauseInventoryScreen(bool isActive)
        {
            pauseInventoryScreen.SetActive(isActive);
        }

        public void ToggleTimer(bool isActive)
        {
            timer.gameObject.SetActive(isActive);
        }

        public void ToggleGameOverUI(bool isActive)
        {
            gameOverUICanvas.SetActive(isActive);
        }

        public void StartTimer()
        {
            timer.GetComponent<Core.UI.Timer>().StartTimer();
        }

        public void EnableRiddlePopUp(Sprite imageForRiddle)
        {
            riddleImage.sprite = imageForRiddle;
            riddlePopUp.SetActive(true);
            riddleImage.gameObject.SetActive(true);
        }

        internal void CloseRiddlePopUp()
        {
            riddleImage.gameObject.SetActive(false);
            riddlePopUp.SetActive(false);
            riddleImage.sprite = null;
        }
    }
}

