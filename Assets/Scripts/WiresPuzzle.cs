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
        private string[,] characterNumeralPairs = new string[16,2]
        {
            { "A","I" },
            { "B","II" },
            { "C","III" },
            { "D","IV" },
            { "E","V" },
            { "F","VI" },
            { "G","VII" },
            { "H","VIII" },
            { "I","IX" },
            { "J","X" },
            { "K","XI" },
            { "L","XII" },
            { "M","XIII" },
            { "N","XIV" },
            { "O","XV" },
            { "P","XVI" }
        };

        private string[,] chosenCharacterNumeralPairs = new string[4,2];

        

        private void Awake()
        {
            AssignCharactersAndNumerals();
        }

        private void PickRandomPair()
        {
            int[] chosenRandom = new int[4];

            for (int row = 0; row < 4; row++)
            { 
                bool chosenRandomExists = true;

                int chosenPairRow;

                do
                {
                     chosenPairRow = UnityEngine.Random.Range(1,16);

                    for (int i = 0; i < chosenRandom.Length; i++)
                    {
                        if (chosenPairRow == chosenRandom[i])
                        {
                            chosenRandomExists = true;
                        }
                        else
                        {
                            chosenRandomExists = false;
                        }
                            
                    }
                    
                }while (chosenRandomExists);

                chosenRandom[row] = chosenPairRow;

                for (int col = 0; col < 2; col++)
                {
                    chosenCharacterNumeralPairs[row,col] =characterNumeralPairs[chosenPairRow,col];
                }
            }
        }

        private void AssignCharactersAndNumerals()
        {
            PickRandomPair();

            Debug.Log("charnumpairlen:" + chosenCharacterNumeralPairs.Length);

            for (int i = 0; i < 4; i++)
            {
                characters[i].SetCharacterString(chosenCharacterNumeralPairs[i, 0]);
            }

            for (int i = 0; i < 4; i++)
            {
                numerals[i].SetNumeralString(chosenCharacterNumeralPairs[0, i]);
            }
            // assign letters to each WireCharacter
            // assign numerals to each WireNumeral.
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



    }
}


