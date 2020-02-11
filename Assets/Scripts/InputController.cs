using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Control
{
    public class InputController : MonoBehaviour
    {

        public static InputController instance;

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            ProcessInputControls();
        }

        private void ProcessInputControls()
        {
            if(StateMachineController.instance.gameState == StateMachineController.State.Menu)
            {

                Debug.Log("gameState in " + StateMachineController.instance.gameState + " state.");

                if (Input.GetButtonDown("Submit"))
                {
                    Debug.Log("You pushed the submit button button.");
                }

                if(Input.GetButtonDown("Cancel"))
                {
                    Debug.Log("You pressed the cancel button.");
                }

                if(Input.GetButtonDown("Inventory"))
                {
                    Debug.Log("You pressed the inventory button.");
                }
            }
            else if(StateMachineController.instance.gameState == StateMachineController.State.Play)
            {
                Debug.Log("gameState in " + StateMachineController.instance.gameState + " state.");
                MovePlayer();
                
            }
            else if(StateMachineController.instance.gameState == StateMachineController.State.Pause)
            {
                Debug.Log("gameState in " + StateMachineController.instance.gameState + " state.");
                // do more stuff
            }
        }

        private void MovePlayer()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(verticalInput) > 0 && Mathf.Abs(horizontalInput) > 0)
            {
                if (Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput))
                {
                    Debug.Log("taking vertical action");
                    horizontalInput = 0;
                }
                else
                {
                    Debug.Log("taking horizontal action");
                    verticalInput = 0;
                }
            }

            Vector3 newDestination = new Vector3(horizontalInput * Player.instance.movementSpeed * Time.deltaTime, verticalInput * Player.instance.movementSpeed * Time.deltaTime, 0);

            transform.position = transform.position + newDestination;
        }

    }

}

