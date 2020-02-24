using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.UI
{
    public class CrosswordPuzzle : MonoBehaviour
    {
        [SerializeField] GameObject[] wordBankWords;

        Journal journal;

        private void Awake()
        {
            journal = FindObjectOfType<Journal>();


        }

        private void OnEnable()
        {
            PopulateWordBank();
        }

        private void Update()
        {
            if(StateMachineController.instance.gameState == StateMachineController.State.Puzzle)
            {
                if(Input.GetButtonDown("Cancel"))
                {
                    ExitPuzzle();
                }
            }
        }

        private void PopulateWordBank()
        {
            bool[] currentlyFoundRiddleIndex = journal.GetActiveRiddles();

            for (int i = 0; i < currentlyFoundRiddleIndex.Length; i++)
            {
                Debug.Log("FoundRiddleIndex " + i + " active status is " + currentlyFoundRiddleIndex[i]);
            }

            for (int i = 0; i < wordBankWords.Length; i++)
            {
                if(currentlyFoundRiddleIndex[i])
                {
                    wordBankWords[i].SetActive(true);
                }
            }
        }

        private void ExitPuzzle()
        {
            GameManager.instance.ExitPuzzle();
        }
    }
}

