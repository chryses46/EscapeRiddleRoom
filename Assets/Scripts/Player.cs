using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public class Player : MonoBehaviour
    {
        public static Player instance;

        public float movementSpeed;


        private void Awake()
        {
            instance = this;
        }

    }
}



