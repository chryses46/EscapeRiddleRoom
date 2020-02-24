using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class JournalRiddleImage : MonoBehaviour
    {

        Image riddleImage;

        [SerializeField] Sprite mysterySprite;

        [SerializeField] Sprite riddleSprite;

        private void Start()
        {
            riddleImage = gameObject.GetComponent<Image>();
        }

        public void SetRiddleImageActive(bool isActive)
        {
            if(isActive)
                gameObject.GetComponent<Image>().sprite = riddleSprite;
        }
    }

}

