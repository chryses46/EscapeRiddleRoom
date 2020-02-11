using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class StateMachineController : MonoBehaviour {


        public static StateMachineController instance;

        public enum GameState {Play, Pause, Menu};

        public GameState gameState = GameState.Menu;


	    void Awake()
        {
            instance = this;
        }

    
    }
}

