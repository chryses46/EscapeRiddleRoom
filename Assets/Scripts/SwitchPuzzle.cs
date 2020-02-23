using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    public class SwitchPuzzle : MonoBehaviour
    {
        [SerializeField] OvenButton[] ovenButtons;

        [SerializeField] GameObject[] ovenFingers;

        OvenButton currentOvenButton;

        int currentFinger = 0;

        bool dpadActive;

        private void Start()
        {
            SetButtonAndFinger();
        }

        private void Update()
        {
            if (StateMachineController.instance.gameState == StateMachineController.State.Puzzle)
            {
                MoveFinger();

                SelectButton();

                ExitPuzzle();
            }
        }

        private void ExitPuzzle()
        {
            if(Input.GetButtonDown("Cancel"))
            {
                GameManager.instance.ExitPuzzle();
            }
        }

        private void SelectButton()
        {
            if (Input.GetButtonDown("Submit"))
            {
                currentOvenButton.FlipButton(false);
            }

            CheckIfSolved();
        }

        private void CheckIfSolved()
        {
            int buttonsUp = 0;

            for (int i = 0; i < ovenButtons.Length; i++)
            {
                if(ovenButtons[i].IsSwitchUp() == true)
                {
                    buttonsUp++;
                }
                else
                {
                    continue;
                }
            }

            if(buttonsUp == ovenButtons.Length)
            {
                GameManager.instance.ExitPuzzle(true,true);
            }
        }

        private void MoveFinger()
        {
            if (!dpadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 1)
            {
                
                dpadActive = true;

                if (currentFinger == ovenFingers.Length)
                {
                    return;
                }
                else if (Input.GetAxis("DPadHorizontal") > 0 && currentFinger <= 2)
                {
                    UnsetButtonAndFinger();
                    currentFinger++;
                    SetButtonAndFinger();
                }
                else if (Input.GetAxis("DPadHorizontal") < 0 && currentFinger >= 1)
                {
                    UnsetButtonAndFinger();
                    currentFinger--;
                    SetButtonAndFinger();
                }
            }
            else if (dpadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 0)
            {
                dpadActive = false;
            }
        }

        private void SetButtonAndFinger()
        {
            ovenFingers[currentFinger].SetActive(true);
            currentOvenButton = ovenButtons[currentFinger];
        }

        private void UnsetButtonAndFinger()
        {
            currentOvenButton = null;
            ovenFingers[currentFinger].SetActive(false);
        }
    }
}

