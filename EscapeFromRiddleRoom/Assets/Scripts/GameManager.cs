using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

namespace Core
{
    public class GameManager : MonoBehaviour {

        public static GameManager instance;

        // Controller detection variables
        public bool playerIndexSet = false;
        PlayerIndex playerIndex;
        GamePadState state;
        GamePadState prevState;

        void Awake ()
        {
            instance = this;
	    }
	
	    void Update () {
		
	    }

        // checks wether or not a controller is connected to the computer
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
    }
}

