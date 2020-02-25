﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.UI
{
    public class CrosswordPuzzle : MonoBehaviour
    {
        [SerializeField] GameObject[] wordBankWords;

        [SerializeField] RowCol[] allRowCols;
        
        RowCol[] currentRowCols;

        RowCol controlRowCol;

        Journal journal;

        private void Awake()
        {
            journal = FindObjectOfType<Journal>();
        }

        private void OnEnable()
        {
            PopulateWordBank();

            InitializeCrossword();
        }

        private void InitializeCrossword()
        {
            controlRowCol = allRowCols[0];

            controlRowCol.SetCurrentHoverCharacter(0);
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

        private void MoveSelector(int movementDirecton)
        {
            switch(controlRowCol.GetMovementDirection())
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
            }
        }

        private void SetCurrentRowCols()
        {

        }

        private void ExitPuzzle()
        {
            GameManager.instance.ExitPuzzle();
        }
    }
}

