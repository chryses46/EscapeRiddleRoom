using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Control
{
    public class InputController : MonoBehaviour
    {

        Player player;

        private void Start()
        {
            player = FindObjectOfType<Player>();
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
                    Debug.Log("gameState in " + StateMachineController.instance.gameState + " state.");
                    player.MovePlayer();
                    break;
                case StateMachineController.State.Pause:
                    Debug.Log("gameState in " + StateMachineController.instance.gameState + " state.");
                    break;
                case StateMachineController.State.Menu:
                    Debug.Log("gameState in " + StateMachineController.instance.gameState + " state.");
                    break;
                default:
                    Commands();
                    break;
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

