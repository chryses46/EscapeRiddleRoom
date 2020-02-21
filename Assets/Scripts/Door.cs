using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    public class Door : MonoBehaviour
    {
        [SerializeField] Sprite unlockImage;
        [SerializeField] Door connectedDoor;
        [SerializeField] Room connectedRoom;
        [SerializeField] AudioClip doorUnlockSound;
        [SerializeField] GameObject playerPortZone;
        [SerializeField] bool isUnlocked;
        [SerializeField] bool flipUnlockImageOnY;   

        protected Player player;

        public void UnlockDoor()
        {
            isUnlocked = true;

            if(flipUnlockImageOnY)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = unlockImage;
                gameObject.GetComponent<SpriteRenderer>().flipY = true;

            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = unlockImage;
            }
            

            //maybe send pop-up that door unlocked?
        }

        public void Interact()
        {
            if(isUnlocked)
            {
                Debug.Log("I transport you now.");
                GameManager.instance.TransitionRooms(connectedRoom, connectedDoor);
                player.ClearInteractable();

            }
            else 
            {
                Debug.Log("This door is locked");
                // send to the pop-up box that the door is locked.
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                InformPlayerOfActions(collision);
            }
        }

        private void InformPlayerOfActions(Collider2D playerCollision)
        {
            player = playerCollision.gameObject.GetComponent<Player>();
            player.SetInteractable(null,null,this);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (player)
            {
                player.ClearInteractable();
            }
        }

        public Vector3 GetPlayerPortZonePosition()
        {
            return playerPortZone.transform.position;
        }

        public Door GetConnectedDoor()
        {
            return connectedDoor;
        }

        public Room GetConnectedRoom()
        {
            return connectedRoom;
        }
    }
}

