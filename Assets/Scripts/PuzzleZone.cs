using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables 
{
    public class PuzzleZone: Interactable
    {
        protected Player player;

        [SerializeField] GameObject linkedPuzzleUIObject;

        [SerializeField] GameObject solvedPuzzleDisplay;

        [SerializeField] Sprite solvedPuzzleDisplayAlt;

        [SerializeField] GameObject[] optionalObjectsToDisableOnSolved;

        [SerializeField] Core.Interactables.Door[] doorsToUnlock;

        private bool isPuzzleSolved;


        private void OnTriggerEnter2D(Collider2D collision)
        {
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
            if (player)
            {
                player.ClearInteractable();
            }
        }

        public void Interact()
        {
            if(!IsLinkedPuzzleSolved())
                GameManager.instance.EnterPuzzle(linkedPuzzleUIObject, this);
        }

        public bool IsLinkedPuzzleSolved()
        {
            return isPuzzleSolved;
        }

        public void SetLinkedPuzzleSolved()
        {
            isPuzzleSolved = true;
            EnableSolvedPuzzleDisplay();

            foreach (Core.Interactables.Door doorToUnlock in doorsToUnlock)
            {
                doorToUnlock.UnlockDoor();
            }
                

        }

        private void EnableSolvedPuzzleDisplay()
        {
            if(solvedPuzzleDisplay)
            {
                solvedPuzzleDisplay.SetActive(true);
            }
            else if(solvedPuzzleDisplayAlt)
            {
                FindObjectOfType<GameBoardHandler>().GetCurrentRoom().GetComponent<SpriteRenderer>().sprite = solvedPuzzleDisplayAlt;

                if(optionalObjectsToDisableOnSolved.Length > 0)
                {
                    for (int i = 0; i < optionalObjectsToDisableOnSolved.Length; i++)
                    {
                        optionalObjectsToDisableOnSolved[i].SetActive(false);
                    }
                }

            }
                
        }
    }
}