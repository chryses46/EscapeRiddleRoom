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
                    PlayControls();
                    break;
                case StateMachineController.State.Puzzle:
                    PuzzleControls();
                    break;
                case StateMachineController.State.Pause:
                    break;
                case StateMachineController.State.Menu: // done
                    if (Input.GetButtonDown("Submit")) { GameManager.instance.StartGame(); }
                    break;
                case StateMachineController.State.Dialog: // done
                    if (Input.GetButtonDown("Submit")) { dialogSystem.UserAdvanceDialog(); }
                    else if(Input.GetButtonDown("Cancel")) { dialogSystem.SkipDialog(); }
                    break;
                default:
                    Commands();
                    break;
            }
        }

        

        private void PlayControls()
        {
            player.MovePlayer();

            if(Input.GetButtonDown("Submit"))
                player.Interact();

            DebugControls();
        }
        private void PuzzleControls()
        {
            // controls for the puzzles which will really just be handled in each puzzle's master script
            // if I had more time, I'd pass something to something and make everything really nice and pretty but w/e
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

