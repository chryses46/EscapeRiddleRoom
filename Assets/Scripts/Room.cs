using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    public class Room : MonoBehaviour
    {
        [SerializeField] Sprite roomImage;

        private void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = roomImage;
        }

        public void FadeRoomOut()
        {
            // animator.ResetTrigger(currentAnimationTrigger);
            // animator.SetTrigger("FadeOut"); -->> Should call DeactivateSelf() when complete
            // currentAnimationTrigger = "FadeOut";
        }

        public void DeactivateSelf()
        {
            gameObject.SetActive(false);
        }

        public void FadeRoomIn()
        {
            // animator.ResetTrigger(currentAnimationTrigger);
            // animator.SetTrigger("FadeIn");
            // currentAnimationTrigger = "FadeIn";
        }
    }
}

