using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables 
{
    public class Puzzle: Interactable
    {
        [SerializeField] Door doorToUnlock;

        protected Player player;

        bool puzzleEnabled;

        private void Awake()
        {
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("entering " + name + "range");

            InformPlayerOfActions(collision);

        }

        private void InformPlayerOfActions(Collider2D playerCollider)
        {
            if (playerCollider.tag == "Player")
            {
                player = playerCollider.gameObject.GetComponent<Player>();
                player.SetInteractable(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("leaving " + name + "range");

            if (player)
            {
                player.ClearInteractable();
                
                //also close puzzle ui
            }

        }

        public void Interact()
        {
            // show puzzle UI
        }
    }
}