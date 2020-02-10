using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class StateMachineController : MonoBehaviour {


        public static StateMachineController instance;
	
	    void Awake()
        {
            instance = this;
        }

    
    }
}

