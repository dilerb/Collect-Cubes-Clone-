using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CC.Managers
{
    public class UIManager : SingletonMono<UIManager>
    {
        [SerializeField] private GameObject joystick;

        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winLevelText;
        [SerializeField] private GameObject loseLevelText;
        [SerializeField] private GameObject mainMenuLevelText;

        [SerializeField] private GameObject playerScoreText;
        [SerializeField] private GameObject aiScoreText;

        [SerializeField] private Timer timer;

        public void SetLevel(int currentLevel)
        {
            loseLevelText.GetComponent<Text>().text = "Level " + currentLevel.ToString();
            winLevelText.GetComponent<Text>().text = "Level " + currentLevel.ToString();
            mainMenuLevelText.GetComponent<Text>().text = "Level " + currentLevel.ToString();
        }

        public void ActivateJoystick()
        {
            joystick.SetActive(true);
        }

        public void DisableJoystick()
        {
            joystick.SetActive(false);
        }

        public void OpenLosePanel()
        {
            joystick.SetActive(false);
            losePanel.SetActive(true);
        }
        public void OpenWinPanel()
        {
            joystick.SetActive(false);
            winPanel.SetActive(true);
        }

        public void SetPlayerScore(int score)
        {
            playerScoreText.GetComponent<TextMesh>().text = score.ToString();
        }
        public void SetAiScore(int score)
        {
            aiScoreText.GetComponent<TextMesh>().text = score.ToString();
        }
    }
}

