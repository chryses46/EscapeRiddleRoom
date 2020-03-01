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
        
        [SerializeField] RowCol[] currentRowCols = new RowCol[2];

        [SerializeField] RowCol controlRowCol;

        private int controlRowColNumOfChars;

        [Tooltip("1=x, 2=y, 3=x+y")]
        [SerializeField] private int movementDirection;

        [SerializeField] private int controlRowColCurrentHoverIndex = 0;

        [SerializeField] private RowCol currentLinkingRowCol;

        [SerializeField] private CrosswordChar currentLinkingCrosswordChar;

        Journal journal;

        [SerializeField] private bool dPadActive;

        [SerializeField] private bool exchangingControlRowCol;

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

            currentRowCols[0] = controlRowCol;

            controlRowCol.gameObject.SetActive(true);

            controlRowCol.SetCurrentHoverCharacter(0);

            controlRowColNumOfChars = controlRowCol.GetNumCharSlots();

            CalculateMovementDirection();
        }

        private void Update()
        {
            if(StateMachineController.instance.gameState == StateMachineController.State.Puzzle)
            {
                switch (movementDirection)
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
            movementDirection = 0;

            for (int i = 0; i < currentRowCols.Length; i++)
            {
                if(currentRowCols[i] != null)
                {
                    movementDirection += currentRowCols[i].GetMovementDirection();
                }
                else
                {
                    continue;
                }   
            }
        }

        private void HorizontallyMoveSelector(int direction = 1)
        {
            switch (direction)
            {
                case 1:
                    if (!dPadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 1)
                    {
                        if (Input.GetAxis("DPadHorizontal") > 0 && controlRowColCurrentHoverIndex < controlRowColNumOfChars - 1)
                        {
                            controlRowCol.SetCurrentHoverCharacter(controlRowColCurrentHoverIndex + 1);
                        }
                        else if (Input.GetAxis("DPadHorizontal") < 0 && controlRowColCurrentHoverIndex > 0)
                        {
                            controlRowCol.SetCurrentHoverCharacter(controlRowColCurrentHoverIndex - 1);
                        }

                        CheckCrossingIndex();

                        dPadActive = true;
                    }
                    else if (dPadActive && Input.GetAxis("DPadHorizontal") == 0)
                    {
                        dPadActive = false;
                    }

                    break;
                case 2:

                    Debug.Log("Switch to horizontal movement");

                    break;
            }
            
            
        }

        private void VerticallyMoveSelector(int direction = 2)
        {
            switch (direction)
            {
                case 1:
                    if(!exchangingControlRowCol)
                    {
                        exchangingControlRowCol = true;
                    
                        SetControlRowCol(direction);
                    }
                    break;
                case 2:
                    if (!dPadActive && Mathf.Abs(Input.GetAxis("DPadVertical")) == 1)
                    {
                        if (Input.GetAxis("DPadVertical") > 0 && controlRowColCurrentHoverIndex < 0)
                        {
                            controlRowCol.SetCurrentHoverCharacter(controlRowColCurrentHoverIndex - 1);
                        }
                        else if (Input.GetAxis("DPadVertical") < 0 && controlRowColCurrentHoverIndex > controlRowColNumOfChars - 1)
                        {
                            controlRowCol.SetCurrentHoverCharacter(controlRowColCurrentHoverIndex + 1);
                        }

                        CheckCrossingIndex();

                        dPadActive = true;
                    }
                    else if (dPadActive && Input.GetAxis("DPadVertical") == 0)
                    {
                        dPadActive = false;
                    }

                    break;
            }
        }

        private void HorizontallyAndVerticallyMoveSelector()
        {
            if (Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 1)
            {
                HorizontallyMoveSelector(controlRowCol.GetMovementDirection());
            }
            else if (Mathf.Abs(Input.GetAxis("DPadVertical")) == 1)
            {
                VerticallyMoveSelector(controlRowCol.GetMovementDirection());
            }else if(dPadActive && (Input.GetAxis("DPadHorizontal") == 0 && Input.GetAxis("DPadVertical") == 0))
            {
                dPadActive = false;
            }
        }

        private void CheckCrossingIndex()
        {
            if(controlRowCol.GetCurrentHoverCharacter().IsCrossingIndexChar())
            {
                for (int i = 0; i < currentRowCols.Length; i++)
                {
                    if(currentRowCols[i] == null)
                    {
                        currentRowCols[i] = controlRowCol.GetCurrentHoverCharacter().GetLinkedRowCol();

                        currentLinkingRowCol = controlRowCol.GetCurrentHoverCharacter().GetLinkedRowCol();

                        currentLinkingRowCol.gameObject.SetActive(true);

                        currentLinkingRowCol.GetCurrentHoverCharacter().ToggleFinger(false);

                        currentLinkingCrosswordChar = controlRowCol.GetCurrentHoverCharacter().GetLinkedCrosswordChar();
                    }
                    else
                    {
                        continue;
                    }
                }
                CalculateMovementDirection();
            }
        }

        

        private void SetControlRowCol(int callingDirection)
        {
            controlRowCol.GetCurrentHoverCharacter().ToggleFinger(false);

            controlRowCol.gameObject.SetActive(false);

            int hoverCharacterIndexToSet = 0;

            for (int i = 0; i < currentLinkingRowCol.GetCrosswordChars().Length; i++)
            {
                if (currentLinkingRowCol.GetCrosswordChars()[i] == currentLinkingCrosswordChar)
                {
                    hoverCharacterIndexToSet = i;
                    break;
                }
            }

            controlRowCol = currentLinkingRowCol;

            controlRowCol.gameObject.SetActive(true);

            SetControlRowColCurrentHoverIndex(hoverCharacterIndexToSet);

            ClearCrossingInformation();

            movementDirection = controlRowCol.GetMovementDirection();

            currentRowCols[0] = controlRowCol;

            controlRowColNumOfChars = controlRowCol.GetNumCharSlots();

            //return control back to the requested direction of movement
            //1  returns control to vertical and 2 returns control to horizontal
            switch (callingDirection)
            {
                case 1:
                    VerticallyMoveSelector();
                    break;
                case 2:
                    HorizontallyMoveSelector();
                    break;

                default:
                    break;
            }

            exchangingControlRowCol = false;

        }

        private void ClearCrossingInformation()
        {
            for (int i = 0; i < currentRowCols.Length; i++)
            {
                currentRowCols[i] = null;
            }

            currentLinkingRowCol = null;

            currentLinkingCrosswordChar = null;

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

