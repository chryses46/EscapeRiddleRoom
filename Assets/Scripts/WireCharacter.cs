using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Interactables
{
    public class WireCharacter : MonoBehaviour
    {
        Text characterText;

        string currentCharacterString;

        private void Start()
        {
            characterText = gameObject.GetComponent<Text>();
        }

        public void SetCharacterString(string givenCharacterString)
        {
            currentCharacterString = givenCharacterString;

            characterText.text = currentCharacterString;
        }

        public string GetCurrentCharacterString()
        {
            return currentCharacterString;
        }
    }
}

