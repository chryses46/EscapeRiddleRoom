using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class StateMachineController : MonoBehaviour
    {
        public enum State {Play, Pause, Menu, Dialog, Puzzle, Bookshelf};

        public State gameState = State.Menu;

        public static StateMachineController instance;

	    void Awake()
        {
            instance = this;
        }
    }
}

