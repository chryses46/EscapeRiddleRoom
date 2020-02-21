using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Interactables
{
    public class WireNumeral : MonoBehaviour
    {
        [SerializeField] Image straightWire;
        [SerializeField] Image oneOverWire;
        [SerializeField] Image twoOverWire;
        [SerializeField] Image threeOverWire;

        Text numeralText;

        private int activeWireImage;

        private string currentNumeralString;

        private string matchingCharacterAnswer;

        WireCharacter chosenWireCharacter;

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

