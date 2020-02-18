using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    public class Door : MonoBehaviour
    {
        private bool isUnlocked;

        public void UnlockDoor()
        {
            isUnlocked = true;
        }
    }
}

