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
            if(StateMachineController.instance.gameState == StateMachineController.GameState.Menu)
            {
                if(Input.GetButtonDown("Submit"))
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
            else if(StateMachineController.instance.gameState == StateMachineController.GameState.Play)
            {
                // do stuff
            }
            else if(StateMachineController.instance.gameState == StateMachineController.GameState.Play)
            {
                // do more stuff
            }
        }
    }

}

