﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Control
{
    public class InputController : MonoBehaviour
    {

       [SerializeField] Player player;

        DialogSystem dialogSystem;

        Core.Journal journal;

        Core.UI.Timer timer;

        private void Start()
        {
            dialogSystem = GetComponent<DialogSystem>();

            journal = GetComponent<Journal>();

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
                    PauseControls();
                    break;
                case StateMachineController.State.Bookshelf:
                    if (Input.GetButtonDown("Cancel")){ FindObjectOfType<Core.Interactables.BookShelfZone>().DisableBookshelf(); } 
                    break;
                case StateMachineController.State.Menu: // done
                    if (Input.GetButtonDown("Submit")) { GameManager.instance.StartGame(); }
                    break;
                case StateMachineController.State.Dialog: // done
                    if (Input.GetButtonDown("Submit")) { dialogSystem.UserAdvanceDialog(); }
                    else if(Input.GetButtonDown("Cancel")) { dialogSystem.SkipDialog(); }
                    break;
                case StateMachineController.State.GameOver:
                    if(Input.GetButtonDown("Submit")) {GameManager.instance.LoadMainMenu(); }
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
            else if(Input.GetButtonDown("Cancel"))
            {
                journal.EnableJournal();
            }

            DebugControls();
        }

        private void PauseControls()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                journal.DisableJournal();
            }
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
                else if(Input.GetKeyDown(KeyCode.Alpha0))
                {
                    journal.SetRiddleIndexActive(0);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    journal.SetRiddleIndexActive(1);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    journal.SetRiddleIndexActive(2);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    journal.SetRiddleIndexActive(3);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    journal.SetRiddleIndexActive(4);
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

