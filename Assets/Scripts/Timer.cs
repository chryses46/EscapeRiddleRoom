using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core.UI
{
    public class Timer : MonoBehaviour
    {
        Text clockText;
        int frames,
            currentMinute = 29,
            currentSecond = 59,
            secondsCounted = 0;

        const int TOTAL_TIME = 1800;

        bool timerRunning;

        float startingTime = 0;

        float clockTime;

        void Start()
        {
            clockText = gameObject.GetComponent<Text>();
            clockText.text = "30:00";

        }

        void Update()
        {
            SetTimerTime();
        }

        private void IterateSeconds()
        {
            startingTime += Time.deltaTime;

            if(startingTime >= 1)
            {
                currentSecond--;

                startingTime = -1;
            }
        }

        private void SetTimerTime()
        {
            if (timerRunning == true)
            {
                IterateSeconds();

                if (currentSecond <= 0)
                {
                    //if (secondsCounted == TOTAL_TIME) TimerEnds();

                    currentMinute--;
                    currentSecond = 59;
                }
                    
                SetClockText();
            }
        }

        private void SetClockText()
        {
            if (currentSecond >= 10)
            {
                clockText.text = currentMinute + ":" + currentSecond;
            }
            else
            {
                clockText.text = currentMinute + ":0" + currentSecond;
            }
            
        }

        // for debugging.
        // Pressing the "T" key will set timerRunning to the opposite value it currently is at.
        public void StartPauseTimer()
        {
            timerRunning = !timerRunning;
        }

        public void StartTimer()
        {
            timerRunning = true;
        }

        public void PauseTimer()
        {
            timerRunning = false;
        }

        private void TimerEnds()
        {
            timerRunning = false;
            
            currentMinute = 0;
            currentSecond = 0;

            Debug.Log("You lose sucka!");
        }

        

      

        

        
    }
}

