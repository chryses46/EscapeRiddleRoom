using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core.Interactables
{
    public class KeypadNumber : MonoBehaviour
    {
        [SerializeField] string thisKeysNumber;

        Image image;

        private void Awake()
        {
            image = gameObject.GetComponent<Image>();
        }

        public string GetKeyNumber()
        {
            return thisKeysNumber;
        }

        public void SetImage(Sprite givenImage)
        {
            image.sprite = givenImage;
        }
        
    }
}

