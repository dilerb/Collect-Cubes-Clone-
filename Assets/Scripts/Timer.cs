using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace CC.Managers
{
    public class Timer : SingletonMono<Timer>
    {
        [SerializeField] private TextMeshProUGUI timerText;

        public float timeRemaining = 10;
        public bool timerIsRunning = false;
        public void StartTimer(float t)
        {
            timeRemaining = t;
            SetTimerText();

            timerIsRunning = true;
        }
        private void Update()
        {
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    SetTimerText();
                }
                else
                {
                    Debug.Log("Time has run out!");

                    timeRemaining = 0;
                    timerIsRunning = false;

                    GameManager.Instance.GameOver();
                }
            }
        }

        private void SetTimerText()
        {
            int minutes = (int)timeRemaining / 60;
            int seconds = (int)timeRemaining % 60;
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (timeRemaining <= 5)
                timerText.color = Color.red;
            else
                timerText.color = Color.black;
        }
    }
}