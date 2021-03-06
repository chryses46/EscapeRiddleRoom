﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    public class RiddleZone : Interactable
    {
        
        UIManager uiManager;

        protected Player player;

        [SerializeField] Sprite riddleImage;

        private bool riddleEnabled;

        [SerializeField] private int riddleIndex;

        private bool riddleFound;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
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

                if(!riddleFound)
                {
                    FindObjectOfType<Journal>().IterateNumRiddlesFound(riddleIndex);

                    riddleFound = true;
                }
                
            }
            else
            {
                uiManager.CloseRiddlePopUp();
                riddleEnabled = false;
            }
        }
    }
}

