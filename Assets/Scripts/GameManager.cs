using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CC.Managers
{
    public class GameManager : SingletonMono<GameManager>
    {
        public bool gameOver = false;
        private int currentLevel;
        private int collectedCubeCount = 0;

        private void Start()
        {
            //levelManager._levelIndex = PlayerPrefs.GetInt("CurrentLevelIndex");

            HCLevelManager.Instance.Init();
            HCLevelManager.Instance.GenerateCurrentLevel();

            Init();

            //Time.timeScale = 0f;
        }
        private void Init()
        {
            currentLevel = GetLevel();
            UIManager.Instance.SetLevel(currentLevel);
            gameOver = true;
        }
        public void StartGame()
        {
            gameOver = false;
            Time.timeScale = 1f;
        }
        public void Restart()
        {
            //MMVibrationManager.Haptic(HapticTypes.LightImpact);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void NextLevel()
        {
            //currentLevel++;
            //PlayerPrefs.SetInt("Level", currentLevel);
            HCLevelManager.Instance.LevelUp();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void GameOver()
        {
            gameOver = true;
            UIManager.Instance.OpenLosePanel();
        }
        private int GetLevel()
        {
            return HCLevelManager.Instance.GetGlobalLevelIndex() + 1;
        }
        internal void IncreaseCollectedCubeCount()
        {
            collectedCubeCount++;

            if (collectedCubeCount >= HCLevelManager.Instance.GetNecessaryCubeNumber())
            {
                UIManager.Instance.OpenWinPanel();
            }
        }
    }
}

