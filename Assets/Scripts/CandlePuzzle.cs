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

        private Vector3 originalOutlinePos;

        private Candle currentSelectedCandle;

        private Candle currentOutlinedCandle;

        private int currentOutlinedCandleOrder = 0;

        private Sprite cachedOutlinedCandleImage;

        private bool dpadActive;

        private void Awake()
        {
            originalOutlinePos = outline.GetComponent<RectTransform>().localPosition;
            currentOutlinedCandle = candles[0];
        }

        private void Update()
        {
            if (StateMachineController.instance.gameState == StateMachineController.State.Puzzle)
            {
                HighlightCandle();

                if (Input.GetButtonDown("Submit"))
                {
                    SelectCandle();
                }
                else if (Input.GetButtonDown("Cancel"))
                {
                    ExitPuzzle();
                }
                
            }
        }

        public void HighlightCandle()
        {
            if (!dpadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 1)
            {
                dpadActive = true;

                if(currentOutlinedCandleOrder == candles.Length)
                {
                    return;
                }
                else if(Input.GetAxis("DPadHorizontal") > 0 && currentOutlinedCandleOrder <= 2)
                {
                    currentOutlinedCandleOrder++;
                    outline.GetComponent<RectTransform>().localPosition = candles[currentOutlinedCandleOrder].GetRectTransformLocalPosition();
                    currentOutlinedCandle = candles[currentOutlinedCandleOrder];
                }
                else if(Input.GetAxis("DPadHorizontal") < 0 && currentOutlinedCandleOrder >= 1)
                {
                    currentOutlinedCandleOrder--;
                    outline.GetComponent<RectTransform>().localPosition = candles[currentOutlinedCandleOrder].GetRectTransformLocalPosition();
                    currentOutlinedCandle = candles[currentOutlinedCandleOrder];
                }
            }
            else if (dpadActive && Mathf.Abs(Input.GetAxis("DPadHorizontal")) == 0)
            {
                dpadActive = false;
            }
        }

        public void SelectCandle()
        {
                if(!currentSelectedCandle)
                {
                    currentSelectedCandle = currentOutlinedCandle;
                    EnableSelected(currentSelectedCandle.GetRectTransformLocalPosition());
                }
                else if(currentOutlinedCandle == currentSelectedCandle)
                {
                    DisableSelected();
                }
                else
                {
                    cachedOutlinedCandleImage = currentOutlinedCandle.GetCandleImage();
                    currentOutlinedCandle.SetCandleImage(currentSelectedCandle.GetCandleImage());
                    currentSelectedCandle.SetCandleImage(cachedOutlinedCandleImage);
                    DisableSelected();
                    CheckIfSolved();
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
            currentSelectedCandle = null;
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
                GameManager.instance.ExitPuzzle(true);
            }
        }

        private void ExitPuzzle()
        {
            ResetOutlinePos();

            DisableSelected();

            GameManager.instance.ExitPuzzle();
        }

        private void ResetOutlinePos()
        {
            outline.GetComponent<RectTransform>().localPosition = originalOutlinePos;
        }
    }
}

