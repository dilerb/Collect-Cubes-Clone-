using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace CC.Managers
{

    public class Timer : MonoBehaviour
    {
        public float timeRemaining = 10;
        public bool timerIsRunning = false;

        private TextMeshProUGUI timerText;
        private void Start()
        {
            timerText = GetComponent<TextMeshProUGUI>();

            SetTimerText();

            timerIsRunning = true;
        }
        void Update()
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
                }
            }
        }

        private void SetTimerText()
        {
            timerText.text = ((int)timeRemaining).ToString();

            if (timeRemaining <= 5)
                timerText.color = Color.red;
            else
                timerText.color = Color.white;
        }
    }
}