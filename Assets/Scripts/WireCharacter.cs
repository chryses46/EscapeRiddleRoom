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

        private void Awake()
        {
            characterText = GetComponent<Text>();
        }

        public void SetNumeralString(string givenNumeralString)
        {
            currentCharacterString = givenNumeralString;

            characterText.text = currentCharacterString;
        }

        public string GetCurrentNumeralString()
        {
            return currentCharacterString;
        }
    }
}

