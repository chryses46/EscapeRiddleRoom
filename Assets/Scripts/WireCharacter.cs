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

        private void Start()
        {
            characterText = gameObject.GetComponent<Text>();
        }

        public void SetCharacterString(string givenCharacterString)
        {
            int random = UnityEngine.Random.Range(1, 9);

            characterText.text = allowableCharacters[random];

            currentCharacterString = allowableCharacters[random];
        }

        public string GetCurrentCharacterString()
        {
            return currentCharacterString;
        }
    }
}

