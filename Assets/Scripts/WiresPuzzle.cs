using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    public class WiresPuzzle : MonoBehaviour
    {
        [SerializeField] WireCharacter[] letters;
        [SerializeField] WireNumeral[] numerals;

        private Dictionary<String, String> letterNumeralPairs = new Dictionary<string, string>
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

        private Dictionary<string, string> chosenLetterNumeralPairs;

        private void Awake()
        {
            AssignLettersAndNumerals();
        }

        private void PickRandomPair()
        {
            for (int count = 0; count < 4; count++)
            {
                // pic from dictionary 
                // add to chosen dictionary
                // ensure a reference number for the pair is made for answer reference
            }
        }

        private void AssignLettersAndNumerals()
        {
            // assign letters to each WireCharacter
            // assign numerals to each WireNumeral.
        }

        private void AssignChosenLettersByRandom()
        {

        }

        private void AssignChosenNumeralsByRandom()
        {

        }
    }
}


