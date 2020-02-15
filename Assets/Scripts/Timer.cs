using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    string CurrentTime = "30:00";
    string Minutes, Seconds;
    bool TimerRunning = false;
    float StartTime = Time.time;
    float ChangeInTime;
    [SerializeField] Text ClockText; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PauseTimer()
    {
        /*if menu  or pause state
        {
            TimerRunning = false;
            Time.timeScale = 0;
        }
        else 
        {
            Time.timeScale = 1;
            bool TimerRunning = true;
        }*/
    }

    private void TimerEnds()
    {
        // set lose lose state
        // triggeer loss function 
    }

    private void SetTimerTime()
    {
        if (TimerRunning = true);
        {
            Debug.Log("SetTimerTIme");
            ChangeInTime = 1800 - Time.time;
            Minutes = ((int)ChangeInTime / 60).ToString();
            Seconds = ((ChangeInTime % 60).ToString("f1"));
            CurrentTime = Minutes + ":" + Seconds;
            ClockText.text = CurrentTime;
            //ClockText.text = "";
        }

    }


    // Update is called once per frame
    void Update()
    {
        SetTimerTime();
        
    }
}
