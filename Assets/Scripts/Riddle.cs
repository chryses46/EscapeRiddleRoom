using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    public class Riddle : Interactable
    {
        
        UIManager uiManager;

        protected Player player;

        [SerializeField] Sprite riddleImage;

        bool riddleEnabled;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
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
                player.SetInteractable(null,this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("leaving " + name + "range");

            if (player)
            {
                player.ClearInteractable();
            }

            if(riddleEnabled)
            {
                uiManager.CloseRiddlePopUp();
                riddleEnabled = false;
            }
        }

        public void Interact()
        {
            if (!riddleEnabled)
            {
                uiManager.EnableRiddlePopUp(riddleImage);
                riddleEnabled = true;
            }
            else
            {
                uiManager.CloseRiddlePopUp();
                riddleEnabled = false;
            }
        }
    }
}

