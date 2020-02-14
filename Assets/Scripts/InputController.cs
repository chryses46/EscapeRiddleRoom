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
                    player.MovePlayer();
                    break;
                case StateMachineController.State.Pause:
                    break;
                case StateMachineController.State.Menu:
                    break;
                case StateMachineController.State.Dialog:
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

