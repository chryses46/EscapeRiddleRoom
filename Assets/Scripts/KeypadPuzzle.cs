using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core.Interactables
{
    public class KeypadPuzzle : MonoBehaviour
    {
        [SerializeField] Sprite finger;

        [SerializeField] KeypadNumber[] numbers;

        [SerializeField] Text numberEntry1;

        [SerializeField] Text numberEntry2;

        private enum Number { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Zero};

        Number currentHoveringNumber = Number.Five;

        KeypadNumber previousKeypadNumber;

        KeypadNumber currentKeyPadNumber;

        bool dpadActive;

        private void Awake()
        {
            currentKeyPadNumber = numbers[4];
            numberEntry1.text = "";
            numberEntry2.text = "";
        }

        private void Update()
        {
            if (StateMachineController.instance.gameState == StateMachineController.State.Puzzle)
            {
                MoveFinger();

                if(Input.GetButtonDown("Submit"))
                {
                    SelectKey();
                }
                else if(Input.GetButtonDown("Cancel"))
                {
                    ClearNumberEntry();
                    
                }
            }
        }

        private void MoveFinger()
        {
            float dPadHorizontal = Input.GetAxis("DPadHorizontal");
            float dPadVertical = Input.GetAxis("DPadVertical");

            if (!dpadActive && (Mathf.Abs(dPadHorizontal) == 1 || Mathf.Abs(dPadVertical) == 1))
            {

                previousKeypadNumber = currentKeyPadNumber;

                NumberDirectionDecider(dPadHorizontal, dPadVertical);

                dpadActive = true;
            }
            else if(dpadActive && dPadHorizontal == 0 && dPadVertical == 0)
            {
                dpadActive = false;
            }
        }

        public void NumberDirectionDecider(float dPadHorizontal, float dPadVertical)
        {
            switch(currentHoveringNumber)
            {
                case Number.One:
                    if(dPadHorizontal > 0)
                    {
                        currentHoveringNumber = Number.Two;
                        currentKeyPadNumber = numbers[1];
                    }
                    else if(dPadVertical < 0)
                    {
                        currentHoveringNumber = Number.Four;
                        currentKeyPadNumber = numbers[3];
                    }
                    break;

                case Number.Two:
                    if (dPadHorizontal < 0)
                    {
                        currentHoveringNumber = Number.One;
                        currentKeyPadNumber = numbers[0];
                    }
                    else if (dPadHorizontal > 0)
                    {
                        currentHoveringNumber = Number.Three;
                        currentKeyPadNumber = numbers[2];
                    }
                    else if(dPadVertical < 0)
                    {
                        currentHoveringNumber = Number.Five;
                        currentKeyPadNumber = numbers[4];
                    }
                    break;

                case Number.Three:
                    if (dPadHorizontal < 0)
                    {
                        currentHoveringNumber = Number.Two;
                        currentKeyPadNumber = numbers[1];
                    }
                    else if (dPadVertical < 0)
                    {
                        currentHoveringNumber = Number.Six;
                        currentKeyPadNumber = numbers[5];
                    }
                    break;

                case Number.Four:
                    if (dPadHorizontal > 0)
                    {
                        currentHoveringNumber = Number.Five;
                        currentKeyPadNumber = numbers[4];
                    }
                    else if (dPadVertical > 0)
                    {
                        currentHoveringNumber = Number.One;
                        currentKeyPadNumber = numbers[0];
                    }
                    else if (dPadVertical < 0)
                    {
                        currentHoveringNumber = Number.Seven;
                        currentKeyPadNumber = numbers[6];
                    }
                    break;

                case Number.Five:
                    if (dPadHorizontal > 0)
                    {
                        currentHoveringNumber = Number.Six;
                        currentKeyPadNumber = numbers[5];
                    }
                    else if (dPadHorizontal < 0)
                    {
                        currentHoveringNumber = Number.Four;
                        currentKeyPadNumber = numbers[3];
                    }
                    else if (dPadVertical > 0)
                    {
                        currentHoveringNumber = Number.Two;
                        currentKeyPadNumber = numbers[1];
                    }
                    else if (dPadVertical < 0)
                    {
                        currentHoveringNumber = Number.Eight;
                        currentKeyPadNumber = numbers[7];
                    }
                    break;

                case Number.Six:
                    if (dPadHorizontal < 0)
                    {
                        currentHoveringNumber = Number.Five;
                        currentKeyPadNumber = numbers[4];
                    }
                    else if (dPadVertical > 0)
                    {
                        currentHoveringNumber = Number.Three;
                        currentKeyPadNumber = numbers[2];
                    }
                    else if (dPadVertical < 0)
                    {
                        currentHoveringNumber = Number.Nine;
                        currentKeyPadNumber = numbers[8];
                    }
                    break;

                case Number.Seven:
                    if (dPadHorizontal > 0)
                    {
                        currentHoveringNumber = Number.Eight;
                        currentKeyPadNumber = numbers[7];
                    }
                    else if (dPadVertical > 0)
                    {
                        currentHoveringNumber = Number.Four;
                        currentKeyPadNumber = numbers[3];
                    }
                    break;

                case Number.Eight:
                    if (dPadHorizontal > 0)
                    {
                        currentHoveringNumber = Number.Nine;
                        currentKeyPadNumber = numbers[8];
                    }
                    else if (dPadHorizontal < 0)
                    {
                        currentHoveringNumber = Number.Seven;
                        currentKeyPadNumber = numbers[6];
                    }
                    else if (dPadVertical > 0)
                    {
                        currentHoveringNumber = Number.Five;
                        currentKeyPadNumber = numbers[4];
                    }
                    else if (dPadVertical < 0)
                    {
                        currentHoveringNumber = Number.Zero;
                        currentKeyPadNumber = numbers[9];
                    }
                    break;

                case Number.Nine:
                    if (dPadHorizontal < 0)
                    {
                        currentHoveringNumber = Number.Eight;
                        currentKeyPadNumber = numbers[7];
                    }
                    else if (dPadVertical > 0)
                    {
                        currentHoveringNumber = Number.Six;
                        currentKeyPadNumber = numbers[5];
                    }
                    break;

                case Number.Zero:
                    if (dPadVertical > 0)
                    {
                        currentHoveringNumber = Number.Eight;
                        currentKeyPadNumber = numbers[7];
                    }
                    break;

                default:
                    break;
                    
            }

            SetActiveHoverNumber();
        }

        private void SetActiveHoverNumber()
        {
            previousKeypadNumber.gameObject.SetActive(false);
            currentKeyPadNumber.gameObject.SetActive(true);
        }

        private void SelectKey()
        {
            SetNumberEntry(currentKeyPadNumber.GetKeyNumber());
        }

        private void ExitPuzzle(bool isSolved = false)
        {
            if(isSolved)
            {
                GameManager.instance.ExitPuzzle(isSolved);
            }
            else
            {
                GameManager.instance.ExitPuzzle();
            }
            
        }

        private void SetNumberEntry(string numberToEnter)
        {
            if(numberEntry1.text == "")
            {
                numberEntry1.text = numberToEnter;
            }
            else if(numberEntry2.text == "")
            {
                numberEntry2.text = numberToEnter;

                if(numberEntry1.text == GameManager.instance.GetKeyPadAnswer(1) && numberEntry2.text == GameManager.instance.GetKeyPadAnswer(2)) ExitPuzzle(true);
            }
            else
            {
                // merp too many numbers
            }
        }

        private void ClearNumberEntry()
        {
            if(numberEntry2.text != "")
            {
                numberEntry2.text = "";
            }
            else if(numberEntry1.text != "")
            {
                numberEntry1.text = "";
            }
            else
            {
                ExitPuzzle();
            }
        }

    }
}

