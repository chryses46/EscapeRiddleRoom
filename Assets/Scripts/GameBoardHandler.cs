using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Interactables
{
    public class GameBoardHandler : MonoBehaviour
    {
        private GameObject currentRoom;

        public GameObject GetCurrentRoom()
        {
            return currentRoom;
        }

        public void SetCurrentRoom(GameObject room)
        {
            currentRoom = room;
        }

        public void MoveRooms()
        {
            // fade player out (call a method from player script)
            // diable currentRoom
            // enable adjacent door's room (need a linking door variable passed in here)
            // set player pos to linking door's playerPos.
            // fade player in (call a method from player script)
        }
    }
}

