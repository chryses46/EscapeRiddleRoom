using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

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
            
        }

        private void Start()
        {
            CheckForControllers();
            dialogSystem = GetComponent<DialogSystem>();
            uiManager = GetComponent<UIManager>();
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
            GetComponent<UIManager>().ToggleMainMenuUI(false);
            GetComponent<UIManager>().TogglePlayUI(true);
            player.gameObject.SetActive(true);
            StateMachineController.instance.gameState = StateMachineController.State.Dialog;
            GetComponent<DialogSystem>().InitiateDialog();
        }

        public void EnterPlayMode()
        {
            StateMachineController.instance.gameState = StateMachineController.State.Play;

        }
    }
}

