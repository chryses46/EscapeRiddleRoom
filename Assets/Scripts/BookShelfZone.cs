using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Interactables
{
    public class BookShelfZone : MonoBehaviour
    {
        [SerializeField] GameObject bookShelfUI;

        protected Player player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            InformPlayerOfActions(collision);
        }

        private void InformPlayerOfActions(Collider2D playerCollider)
        {
            if (playerCollider.tag == "Player")
            {
                player = playerCollider.gameObject.GetComponent<Player>();
                player.SetInteractable(null, null,null,this);
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
            bookShelfUI.SetActive(true);
            StateMachineController.instance.gameState = StateMachineController.State.Bookshelf;
        }

        public void DisableBookshelf()
        {
            bookShelfUI.SetActive(false);
            StateMachineController.instance.gameState = StateMachineController.State.Play;
        }
    }
}

