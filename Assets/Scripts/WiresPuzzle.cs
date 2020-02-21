using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    public class WiresPuzzle : MonoBehaviour
    {
        [SerializeField] WireNumeral[] numerals;
        [SerializeField] WireCharacter[] characters;
        [SerializeField] GameObject[] numeralFingers;
        [SerializeField] GameObject[] characterFingers;
        enum SelectionState { NUMERALS, LETTERS };

        SelectionState selectionState = SelectionState.NUMERALS;

        //KEY is character
        //VALUE is numeral
        private void Awake()
        {
        }

        private void Update()
        {
            if(StateMachineController.instance.gameState == StateMachineController.State.Puzzle)
            {
                MoveFinger();
                SelectNumeral();
                
                if(Input.GetButtonDown("Cancel"))
                {
                    ExitPuzzle(true);
                }


            }
        }


        private void AssignChosenCharactersByRandom()
        {
            // iterate through the available characters array
            // place one of the characters from the chosenCharacterNumeralPairs in each character's character.SetCharacterString();
        }

        private void AssignChosenNumeralsByRandom()
        {
            // iterate through the available numerals array
            // place one of the numerals from the chosenCharacterNumeralPairs in each numerals's character.SetNumeralString();
            // set the numerals[i].SetMatchingCharacterAnswer(chosenCharacterNumeralPairs<KEY> --for this value)
        }


        private void MoveFinger()
        {
            //when NUMERAL state ----
            //defaultHoverNumeral =  0;
            // using dpad horizontal, update currentHoverNumeral++ or -- based on direction
            //on A, SelectNumeral();

            //when LETTER state ----
            //default potentialChatacterMatch = 0;
            // usind dpad horixontal, update currentHoverCharacter++ or -- based on direction
            // each time the currentHoverCharacter is updated, call the activeWireNumeral.SetActiveWireImage(currentHoverCharacter)
            // on A selectCharacter
        }

        private void SelectNumeral()
        {
            //set activeWireNumeral = currentHoverNumeral
            // set selectionState = SelectionState.LETTER
        }

        private void SelectCharacter()
        {
            // set 
        }

        private void ExitPuzzle(bool isSolved = false)
        {
            if (isSolved)
            {
                GameManager.instance.ExitPuzzle(isSolved);
            }
            else
            {
                GameManager.instance.ExitPuzzle();
            }

        }

    }
}


