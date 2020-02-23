using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Interactables
{
    public class WireNumeral : MonoBehaviour
    {
        [SerializeField] Image hangingWire;
        [SerializeField] Image straightWire;
        [SerializeField] Image oneOverWire;
        [SerializeField] Image twoOverWire;
        [SerializeField] Image threeOverWire;

        Text numeralText;
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

        private string matchingCharacterAnswer;

        private void Awake()
        {
            numeralText = GetComponent<Text>();
        }

        public void SetNumeralString(int numeralLocation)
        {
            numeralText.text = allowableNumerals[numeralLocation];
        }


























        public string GetCurrentNumeralString()
        {
            return currentNumeralString;
        }




        public void SetActiveWireImage(int selectedCharacterNode)
        {
            switch(selectedCharacterNode)
            {

            }
        }

        public void SetMatchingCharacterAnswer(string answer)
        {
            matchingCharacterAnswer = answer;
        }


    }
}

