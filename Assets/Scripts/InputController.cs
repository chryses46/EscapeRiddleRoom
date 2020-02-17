using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Control
{
    public class InputController : MonoBehaviour
    {

       [SerializeField] Player player;
        DialogSystem dialogSystem;
        Core.UI.Timer timer;

        private void Start()
        {
            dialogSystem = GetComponent<DialogSystem>();
            timer = FindObjectOfType<Core.UI.Timer>();
        }

        private void Update()
        {
            ProcessInputControls(StateMachineController.instance.gameState);
        }

        private void ProcessInputControls(StateMachineController.State state)
        {

            switch (state)
            {
                case StateMachineController.State.Play:
                    player.MovePlayer();
                    DebugControls();
                    break;
                case StateMachineController.State.Pause:
                    break;
                case StateMachineController.State.Menu:
                    if (Input.GetButtonDown("Submit")) { GameManager.instance.StartGame(); }
                    break;
                case StateMachineController.State.Dialog:
                    if (Input.GetButtonDown("Submit")) { dialogSystem.UserAdvanceDialog(); }
                    else if(Input.GetButtonDown("Cancel")) { dialogSystem.SkipDialog(); }
                    break;
                default:
                    Commands();
                    break;
            }
        }

        private void DebugControls()
        {
            if(Debug.isDebugBuild)
            {
                if(Input.GetKeyDown(KeyCode.T))
                {
                    timer.StartPauseTimer();
                }
            }
        }

        private static void Commands()
        {
            if (Input.GetButtonDown("Submit"))
            {
                Debug.Log("You pushed the submit button button.");
            }

            if (Input.GetButtonDown("Cancel"))
            {
                Debug.Log("You pressed the cancel button.");
            }

            if (Input.GetButtonDown("Inventory"))
            {
                Debug.Log("You pressed the inventory button.");
            }
        }


    }

}

