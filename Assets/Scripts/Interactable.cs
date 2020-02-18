using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Interactable : MonoBehaviour
    {
        Player player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("entering " + name + "range");

            InformPlayerOfActions(collision);

        }

        private void InformPlayerOfActions(Collider2D playerCollider)
        {
          if(playerCollider.tag == "Player")
            {
                player = playerCollider.gameObject.GetComponent<Player>();
                player.SetInteractable(this);
            }
        }

        public void Interact()
        {
            // Do this when the A button is pressed.

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("leaving " + name + "range");

            if(player)
            {
                player.ClearInteractable();
            }
        }
    }
}
