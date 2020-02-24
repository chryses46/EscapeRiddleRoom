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

        enum SelectionState { NUMERALS, CHARACTERS };

        /// <summary>
        /// The following fields are serialized for development and should be de-serialized before public release.
        /// </summary>

        [SerializeField] SelectionState selectionState = SelectionState.NUMERALS;

        [SerializeField] WireNumeral currentNumeral;

        [SerializeField] WireCharacter currentCharacter;

        private const int LOWER_NUMERAL_AND_CHARACTER_BOUND = 0;

        private const int UPPER_NUMERAL_AND_CHARACTER_BOUND = 10;
        
        // Making each of these -1 initially will allow 0 to be set. Elsewise, 0 is the default int when declaring a blank array of any length.
        private int[] selectedNumeralAndCharacterPairs = new int[4] { -1,-1,-1,-1 };

        private int currentNumeralFinger = 0;

        private int currentCharacterFinger = 0;

        private bool dpadActive;

        private void Start()
        {
            InitializePuzzle();
        }

        private void InitializePuzzle()
        {
            ChooseNumeralAndCharacterPairs();

            SetNumerals();

            SetCharacters();

            numeralFingers[currentNumeralFinger].SetActive(true);

            currentNumeral = numerals[currentNumeralFinger];
        }

        private void Update()
        {
            if(StateMachineController.instance.gameState == StateMachineController.State.Puzzle)
            {
                MoveFinger();
                
                if(selectionState == SelectionState.NUMERALS)
                {
                    SelectNumeral();
                }
                else if(selectionState == SelectionState.CHARACTERS)
                {
                    SelectCharacter();
                }
                
                if(Input.GetButtonDown("Cancel"))
                {
                    ExitPuzzle();
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
            int[] occupiedNumeralArrayElement = new int[4] { -1, -1, -1, -1 };

            for (int i = 0; i <=3; i++)
            {

                numerals[GetRandomElementForGivenArray(0, 4, occupiedNumeralArrayElement, i)].SetNumeralString(selectedNumeralAndCharacterPairs[i]);
                
            }
        }

        private void SetCharacters()
        {
            int[] occupiedCharacterArrayElement = new int[4] { -1, -1, -1, -1 };

            for (int i = 0; i <= 3; i++)
            {

                characters[GetRandomElementForGivenArray(0, 4, occupiedCharacterArrayElement, i)].SetCharacterString(selectedNumeralAndCharacterPairs[i]);

            }
        }

        private void MoveFinger()
        {
            if(selectionState == SelectionState.NUMERALS)
            {
                if (!dpadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 1)
                {

                    dpadActive = true;

                    if (currentNumeralFinger == numeralFingers.Length)
                    {
                        return;
                    }
                    else if (Input.GetAxis("DPadHorizontal") > 0 && currentNumeralFinger <= 2)
                    {
                        UnsetNumeralAndFinger();
                        currentNumeralFinger++;
                        SetNumeralAndFinger();
                    }
                    else if (Input.GetAxis("DPadHorizontal") < 0 && currentNumeralFinger >= 1)
                    {
                        UnsetNumeralAndFinger();
                        currentNumeralFinger--;
                        SetNumeralAndFinger();
                    }
                }
                else if (dpadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 0)
                {
                    dpadActive = false;
                }
            }
            else if(selectionState == SelectionState.CHARACTERS)
            {
                if (!dpadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 1)
                {

                    dpadActive = true;

                    if (currentCharacterFinger == characterFingers.Length)
                    {
                        return;
                    }
                    else if (Input.GetAxis("DPadHorizontal") > 0 && currentCharacterFinger <= 2)
                    {
                        UnsetCharacterAndFinger();
                        currentCharacterFinger++;
                        SetCharacterAndFinger();
                        
                    }
                    else if (Input.GetAxis("DPadHorizontal") < 0 && currentCharacterFinger >= 1)
                    {
                        UnsetCharacterAndFinger();
                        currentCharacterFinger--;
                        SetCharacterAndFinger();
                    }
                }
                else if (dpadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 0)
                {
                    dpadActive = false;
                }
            }
        }

        private void SetNumeralAndFinger()
        {
            currentNumeral = numerals[currentNumeralFinger];
            numeralFingers[currentNumeralFinger].SetActive(true);
        }

        private void UnsetNumeralAndFinger()
        {
            currentNumeral = null;
            numeralFingers[currentNumeralFinger].SetActive(false);
        }

        private void SetCharacterAndFinger()
        {
            currentCharacter = characters[currentCharacterFinger];
            characterFingers[currentCharacterFinger].SetActive(true);
            currentNumeral.SetActiveWireImage(currentCharacterFinger);
        }

        private void UnsetCharacterAndFinger()
        {
            currentCharacter = null;
            characterFingers[currentCharacterFinger].SetActive(false);
        }

        private void SelectNumeral()
        {
            if(Input.GetButtonDown("Submit"))
            {
                selectionState = SelectionState.CHARACTERS;

                numeralFingers[currentNumeralFinger].SetActive(false);

                currentNumeral.IsWireDisconnected(false);

                currentCharacterFinger = 0;

                SetCharacterAndFinger();
            }
        }

        private void SelectCharacter()
        {
            if (Input.GetButtonDown("Submit"))
            {
                selectionState = SelectionState.NUMERALS;

                if(currentCharacter.HasAttachedWire())
                {
                    currentCharacter.ToggleWireAttached(false, null);

                    currentCharacter.ToggleWireAttached(true, numerals[currentNumeralFinger]);
                }
                else
                {
                    currentCharacter.ToggleWireAttached(true, numerals[currentNumeralFinger]);
                }
                    

                characterFingers[currentCharacterFinger].SetActive(false);
                
                currentNumeralFinger = 0;

                currentNumeral = numerals[currentNumeralFinger];

                numeralFingers[currentNumeralFinger].SetActive(true);

                CheckIfSolved();
            }
        }

        private void CheckIfSolved()
        {
            int matched = 0;

            for (int i = 0; i < selectedNumeralAndCharacterPairs.Length; i++)
            {
                if(characters[i].HasAttachedWire() && characters[i].GetCurrentStringLocation() == characters[i].CurrentAttachedNumeral().GetCurrentNumeralStringLocation())
                {
                    matched++;
                }
            }

            if(matched == 4)
            {
               ExitPuzzle(true);
            }
        }

        private void ExitPuzzle(bool isSolved = false)
        {
            if (isSolved)
            {
                GameManager.instance.ExitPuzzle(isSolved);
            }
            else
            {
                ResetPuzzle();

                GameManager.instance.ExitPuzzle();

            }
        }

        private void ResetPuzzle()
        {
            selectionState = SelectionState.NUMERALS;

            currentNumeral = numerals[0];

            currentCharacter = null;

            numeralFingers[currentNumeralFinger].SetActive(false);
        }

        /// <summary>
        /// This method returns a random array element.
        /// </summary>
        /// <param name="lowerRandomNumberBound"> The lower bound of the returned random number (inclusive).</param>
        /// <param name="upperRandomNumberBound"> The upper bound of the returned random number (not inclusive).</param>
        /// <param name="array"> The array in which to check against for uniqueness.</param>
        /// <param name="currentArrayElementIteration"> The current for-loop iteration for the checking array.</param>
        /// <returns></returns>
        private int GetRandomElementForGivenArray(int lowerRandomNumberBound, int upperRandomNumberBound, int[] array, int currentArrayElementIteration)
        {
            bool inArray = true;

            int randomNumber;

            do
            {
                randomNumber = UnityEngine.Random.Range(lowerRandomNumberBound, upperRandomNumberBound);

                bool containsMatch = false;

                foreach (int num in array)
                {
                    if (randomNumber == num)
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
    }
}