using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using Core.UI;
using UnityEngine.UI;

namespace Core
{
    public class GameManager : MonoBehaviour {

        public static GameManager instance;

        // Controller detection variables
        private bool playerIndexSet = false;
        PlayerIndex playerIndex;
        GamePadState state;
        GamePadState prevState;

        [SerializeField] Player player;

        UIManager uiManager;
        DialogSystem dialogSystem;

        void Awake ()
        {
            instance = this;
            CheckForControllers();
            dialogSystem = GetComponent<DialogSystem>();
            uiManager = GetComponent<UIManager>();
        }

        private void Start()
        {
            
        }

        void Update ()
        {
            CheckForControllers();
        }

        // checks whether or not a controller is connected to the computer
        private void CheckForControllers()
        {
            // Find a PlayerIndex, for a single player game
            // Will find the first controller that is connected ans use it
            if (!playerIndexSet || !prevState.IsConnected)
            {
                for (int i = 0; i < 4; ++i)
                {
                    PlayerIndex testPlayerIndex = (PlayerIndex)i;
                    GamePadState testState = GamePad.GetState(testPlayerIndex);
                    if (testState.IsConnected)
                    {
                        Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                        playerIndex = testPlayerIndex;
                        playerIndexSet = true;
                    }
                }
            }

            prevState = state;
            state = GamePad.GetState(playerIndex);
        }

        public void StartGame()
        {
            uiManager.ToggleMainMenuUI(false);
            uiManager.TogglePlayUI(true);
            player.gameObject.SetActive(true);
            StateMachineController.instance.gameState = StateMachineController.State.Dialog;
            dialogSystem.InitiateDialog();
        }
    }
}

