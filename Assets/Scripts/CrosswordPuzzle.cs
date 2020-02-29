using System;
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

        private int controlRowColNumOfChars;

        private int controlRowColMovementDir;

        private int controlRowColCurrentHoverIndex = 0;

        Journal journal;

        private bool dPadActive;

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

            controlRowCol.gameObject.SetActive(true);

            controlRowCol.SetCurrentHoverCharacter(0);

            controlRowColNumOfChars = controlRowCol.GetNumCharSlots();

            CalculateMovementDirection();
        }

        private void Update()
        {
            if(StateMachineController.instance.gameState == StateMachineController.State.Puzzle)
            {
                switch (controlRowColMovementDir)
                {
                    case 1:
                        HorizontallyMoveSelector();
                        break;
                    case 2:
                        VerticallyMoveSelector();
                        break;
                    case 3:
                        HorizontallyAndVerticallyMoveSelector();
                        break;
                }

                if (Input.GetButtonDown("Cancel"))
                {
                    ExitPuzzle();
                }
            }
        }

        private void PopulateWordBank()
        {
            bool[] currentlyFoundRiddleIndex = journal.GetActiveRiddles();

            for (int i = 0; i < wordBankWords.Length; i++)
            {
                if(currentlyFoundRiddleIndex[i])
                {
                    wordBankWords[i].SetActive(true);
                }
            }
        }

        private void CalculateMovementDirection()
        {
            for (int i = 0; i < currentRowCols.Length; i++)
            {
                controlRowColMovementDir += currentRowCols[i].GetMovementDirection();
            }
        }

        private void HorizontallyMoveSelector()
        {
            if( !dPadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 1)
            {
                if (Input.GetAxis("DPadHorizontal") > 0 && controlRowColCurrentHoverIndex < controlRowColNumOfChars - 1)
                {
                    controlRowCol.SetCurrentHoverCharacter(controlRowColCurrentHoverIndex + 1);
                }
                else if (Input.GetAxis("DPadHorizontal") < 0 && controlRowColCurrentHoverIndex > 0)
                {
                    controlRowCol.SetCurrentHoverCharacter(controlRowColCurrentHoverIndex - 1);
                }

                dPadActive = true;   
            }
            else if(dPadActive && Input.GetAxis("DPadHorizontal") == 0 )
            {
                dPadActive = false;
            }
            
        }

        private void VerticallyMoveSelector()
        {
            // same as horiz, but vertical
        }

        private void HorizontallyAndVerticallyMoveSelector()
        {
            throw new NotImplementedException();
        }

        private void SetCurrentRowCols()
        {

        }

        public void SetControlRowColCurrentHoverIndex(int index)
        {
            controlRowColCurrentHoverIndex = index;
        }

        private void ExitPuzzle()
        {
            GameManager.instance.ExitPuzzle();
        }
    }
}

