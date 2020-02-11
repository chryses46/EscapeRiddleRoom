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
                Player.instance.MovePlayer();
                
            }
            else if(StateMachineController.instance.gameState == StateMachineController.State.Pause)
            {
                Debug.Log("gameState in " + StateMachineController.instance.gameState + " state.");
                // do more stuff
            }
        }

        

    }

}

