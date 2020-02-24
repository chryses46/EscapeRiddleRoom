using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Interactables
{
    public class WireCharacter : MonoBehaviour
    {
        Text characterText;

        int currentCharacterStringLocation;

        private bool isWireAttached;

        private WireNumeral currentAttachedNumeral;

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
            characterText.text = allowableCharacters[stringLocation];

            currentCharacterStringLocation = stringLocation;
        }

        public int GetCurrentStringLocation()
        {
            return currentCharacterStringLocation;
        }

        public bool HasAttachedWire()
        {
            return isWireAttached;
        }

        public WireNumeral CurrentAttachedNumeral()
        {
            return currentAttachedNumeral;
        }

        public void ToggleWireAttached(bool isAttached, WireNumeral attachedNumeral)
        {
            if(!isAttached)
            {
                currentAttachedNumeral.IsWireDisconnected(true);
            }
            
            isWireAttached = isAttached;
            currentAttachedNumeral = attachedNumeral;
        }
    }
}

