using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Interactables
{
    public class WireNumeral : MonoBehaviour
    {
        Text numeralText;

        string currentNumeralString;

        private void Awake()
        {
            numeralText = GetComponent<Text>();
        }

        public void SetNumeralString(string givenNumeralString)
        {
            currentNumeralString = givenNumeralString;

            numeralText.text = currentNumeralString;
        }

        public string GetCurrentNumeralString()
        {
            return currentNumeralString;
        }
    }
}

