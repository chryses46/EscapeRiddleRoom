using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public class CandlePuzzle : MonoBehaviour
    {
        [SerializeField] GameObject outline;
        [SerializeField] GameObject selected;
        [SerializeField] Candle[] candles;

        private int numberOfCandles = 4;

        private Vector3 originalHighlightPos;

        private Candle currentSelectedCandle;

        private Candle currentHighlightedCandle;

        private int currentCandleHighlightOrder = 0;

        private Sprite cachedHighlightedImage;

        private bool dpadActive;

        private void Awake()
        {
            originalHighlightPos = outline.GetComponent<RectTransform>().localPosition;
            currentHighlightedCandle = candles[0];
        }

        private void Update()
        {
            if (StateMachineController.instance.gameState == StateMachineController.State.Puzzle)
            {
                HighlightCandle();
                SelectCandle();
            }
        }

        public void HighlightCandle()
        {
            if (!dpadActive && Mathf.Abs(Input.GetAxis("Horizontal")) == 1)
            {
                dpadActive = true;

                if(currentCandleHighlightOrder == candles.Length)
                {
                    return;
                }
                else if(Input.GetAxis("Horizontal") > 0 && currentCandleHighlightOrder <= 2)
                {
                    currentCandleHighlightOrder++;
                    outline.GetComponent<RectTransform>().localPosition = candles[currentCandleHighlightOrder].GetRectTransformLocalPosition();
                    currentHighlightedCandle = candles[currentCandleHighlightOrder];
                }
                else if(Input.GetAxis("Horizontal") < 0 && currentCandleHighlightOrder >= 1)
                {
                    currentCandleHighlightOrder--;
                    outline.GetComponent<RectTransform>().localPosition = candles[currentCandleHighlightOrder].GetRectTransformLocalPosition();
                    currentHighlightedCandle = candles[currentCandleHighlightOrder];
                }
            }
            else if (dpadActive && Mathf.Abs(Input.GetAxis("Horizontal")) == 0)
            {
                dpadActive = false;
            }
        }

        public void SelectCandle()
        {
            if(Input.GetButtonDown("Submit"))
            {
                if(!currentSelectedCandle)
                {
                    currentSelectedCandle = currentHighlightedCandle;
                    EnableSelected(currentSelectedCandle.GetRectTransformLocalPosition());
                }
                else if(currentHighlightedCandle == currentSelectedCandle)
                {
                    DisableSelected();
                }
                else
                {
                    cachedHighlightedImage = currentHighlightedCandle.GetCandleImage();
                    currentHighlightedCandle.SetCandleImage(currentSelectedCandle.GetCandleImage());
                    currentSelectedCandle.SetCandleImage(cachedHighlightedImage);
                    DisableSelected();
                    currentSelectedCandle = null;
                    CheckIfSolved();
                }
                    
            }
               
        }

        public void EnableSelected(Vector3 candlePosition)
        {
            selected.GetComponent<RectTransform>().localPosition = candlePosition;
            selected.SetActive(true);
        }

        private void DisableSelected()
        {
            selected.SetActive(false);
        }

        private void CheckIfSolved()
        {
            int matches = 0;

            for (int i = 0; i < candles.Length; i++)
            {
                if(candles[i].IsSolved())
                {
                    matches++;
                }
            }

            if(matches == candles.Length)
            {
                Debug.Log("Solved!");

                //unlock door
                    // in door script, will need to create a "unlock" method
                        // method will update the 
                            // door direction sprite to the correct arrow
                            // set door to "unlocked" - something the player class should see when stepping into a door collider
                        // when it's unlocked, and the player steps in, the player triggers a transition to the adjacent room.
                
                // Call FoyerPuzzleSolved from GameManager
                    // will disable this puzzle UI
                    // will re-enable the Foyer
                    // will re-enable the Player
                    // will set the state to Play

            }
        }
    }
}

