using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Interactables
{
    public class WireNumeral : MonoBehaviour
    {
        [SerializeField] Image disconnectedWire;

        [SerializeField] Image[] wireImages;

        Text numeralText;

        private int currentNumeralStringLocation;

        string[] allowableNumerals = new string[]
        {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII",
            "IX",
            "X"
        };

        private int activeWireImage;

        private string currentNumeralString;

        private void Awake()
        {
            numeralText = GetComponent<Text>();
        }

        public void SetNumeralString(int numeralLocation)
        {
            numeralText.text = allowableNumerals[numeralLocation];

            currentNumeralStringLocation = numeralLocation;
        }

        public int GetCurrentNumeralStringLocation()
        {
            return currentNumeralStringLocation;
        }

        public void SetActiveWireImage(int selectedCharacterNode)
        {
            wireImages[activeWireImage].gameObject.SetActive(false);

            activeWireImage = selectedCharacterNode;

            wireImages[activeWireImage].gameObject.SetActive(true);
        }

        public void IsWireDisconnected(bool isDisconnected)
        {
            if(isDisconnected)
            {
                disconnectedWire.gameObject.SetActive(true);

                wireImages[activeWireImage].gameObject.SetActive(false);
            }
            else
            {
                disconnectedWire.gameObject.SetActive(false);
            }
        }
    }
}

