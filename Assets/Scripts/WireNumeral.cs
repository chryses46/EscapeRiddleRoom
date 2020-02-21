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

        WireCharacter chosenWireCharacter;

        private void Awake()
        {
            numeralText = GetComponent<Text>();
            SetNumeralString();
        }

        public void SetNumeralString()
        {
            int random = UnityEngine.Random.Range(1, 9);

            numeralText.text = allowableNumerals[random];

            currentNumeralString = allowableNumerals[random];
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

        public void SetChosenWireCharacter(WireCharacter chosenCharacter)
        {
            chosenWireCharacter = chosenCharacter;

        }

        public void SetMatchingCharacterAnswer(string answer)
        {
            matchingCharacterAnswer = answer;
        }


        public bool IsChosenWireCharacterMatching()
        {

            if(chosenWireCharacter.GetCurrentCharacterString() == matchingCharacterAnswer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

