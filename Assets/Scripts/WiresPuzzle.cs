﻿using System;
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

        private const int LOWER_NUMERAL_AND_CHARACTER_BOUND = 0;

        private const int UPPER_NUMERAL_AND_CHARACTER_BOUND = 9;
        
        private int[] selectedNumeralAndCharacterPairs = new int[4];

        private void Awake()
        {
            ChooseNumeralAndCharacterPairs();
            SetNumerals();
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


        private void ChooseNumeralAndCharacterPairs()
        {

            for (int i = 0; i <= 3; i++)
            {
                GetRandomElementForGivenArray(LOWER_NUMERAL_AND_CHARACTER_BOUND, UPPER_NUMERAL_AND_CHARACTER_BOUND, selectedNumeralAndCharacterPairs, i);
            }
        }

        private void SetNumerals()
        {

            int[] occupiedNumeralArrayElement = new int[4];

            for (int i = 0; i <=3; i++)
            {
                numerals[GetRandomElementForGivenArray(0, 3, occupiedNumeralArrayElement, i)].SetNumeralString(selectedNumeralAndCharacterPairs[i]);
            }
        }

        private void SetCharacterAndNumeral(int randomCharacterOrNumberal)
        {
                // make i random as well eventually for each numerals and characters
               
            

            //characters[elementPositionInArray].SetCharacterString(randomCharacterOrNumberal);
        }

        /// <summary>
        /// This method returns a random array element.
        /// </summary>
        /// <param name="lowerRandomNumberBound"> The lower bound of the returned random number.</param>
        /// <param name="upperRandomNumberBound"> The upper bound of the returned random number.</param>
        /// <param name="array"> The array in which to check against for uniqueness.</param>
        /// <param name="currentArrayElementIteration"> The current for-loop iteration for the checking array.</param>
        /// <returns></returns>
        private int GetRandomElementForGivenArray(int lowerRandomNumberBound, int upperRandomNumberBound, int[] array ,  int currentArrayElementIteration)
        {
            bool inArray = true;

            int randomNumber;

            do
            {
                randomNumber = UnityEngine.Random.Range(lowerRandomNumberBound, upperRandomNumberBound);

                bool containsMatch = false;

                for (int j = 0; j < array.Length; j++)
                {
                    if (randomNumber == array[j])
                    {
                        containsMatch = true;
                    }
                }

                if (!containsMatch)
                {
                    inArray = false;
                }

            } while (inArray);

            array[currentArrayElementIteration] = randomNumber;

            return randomNumber;
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


