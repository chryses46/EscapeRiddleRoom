using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Interactables
{
    public class GameBoardHandler : MonoBehaviour
    {
        private Room currentRoom;

        public Room GetCurrentRoom()
        {
            return currentRoom;
        }

        public void SetCurrentRoom(Room room)
        {
            currentRoom = room;
        }

        public void ToggleCurrentRoom(bool isActive)
        {
            if(currentRoom)
            {
                currentRoom.gameObject.SetActive(isActive);
            }
        }

        public void MoveRooms(Room targetRoom)
        {
            currentRoom.FadeRoomOut();

            currentRoom.DeactivateSelf(); // remove once animation complete

            SetCurrentRoom(targetRoom);

            currentRoom.gameObject.SetActive(true);

            currentRoom.FadeRoomIn();
        }
    }
}

