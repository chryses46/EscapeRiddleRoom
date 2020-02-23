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

        string[] allowableCharacters = new string[]
        {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
        };

        private void Awake()
        {
            characterText = GetComponent<Text>();
        }

        public void SetCharacterString(int stringLocation)
        {
            Debug.Log("stringLocation is :" + stringLocation);
            characterText.text = allowableCharacters[stringLocation];
        }

        public string GetCurrentCharacterString()
        {
            return currentCharacterString;
        }
    }
}

