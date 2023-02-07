using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CC.Managers
{
    public class GameManager : SingletonMono<GameManager>
    {
        public enum GameMode
        {
            Classic,
            TimeChallange,
            RivalAI
        }

        [SerializeField] public GameMode gameMode;
        [SerializeField] private GameObject ai;

        internal bool gameOver = false;
        private int currentLevel;
        private int collectedCubeCount = 0;
        private int collectedCubeCountByAI = 0;
        private int initialTimeLimit = 0;

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
            ObjectPooler.Instance.Init();
            currentLevel = GetLevel();
            initialTimeLimit = HCLevelManager.Instance.GetTimeLimit();
            UIManager.Instance.SetLevel(currentLevel);

            StartGame();
        }
        public void StartGame()
        {
            gameOver = false;
            //Time.timeScale = 1f;
            CubeSpawner.Instance.StartSpawn(gameMode);

            if (gameMode == GameMode.TimeChallange)
            {
                Timer.Instance.StartTimer(initialTimeLimit);
            }
            else if (gameMode == GameMode.RivalAI)
            {
                Timer.Instance.StartTimer(initialTimeLimit);
                ai.GetComponent<AI.Controller.AIController>().Init();
            }
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

            if (gameMode == GameMode.TimeChallange || gameMode == GameMode.RivalAI)
            {
                CubeSpawner.Instance.StopSpawn();
                CheckWinLose();

                if (ai != null)
                    ai.GetComponent<AI.Controller.AIController>().StopMovement();
            }
        }
        private int GetLevel()
        {
            return HCLevelManager.Instance.GetGlobalLevelIndex() + 1;
        }
        internal void IncreaseCollectedCubeCount()
        {
            collectedCubeCount++;

            if (gameMode == GameMode.Classic)
            {
                CheckWinLose();
            }
            else if (gameMode == GameMode.TimeChallange)
            {
                UIManager.Instance.SetPlayerScore(collectedCubeCount);
            }
            else if (gameMode == GameMode.RivalAI)
            {
                UIManager.Instance.SetPlayerScore(collectedCubeCount);
            }
        }
        internal void IncreaseCollectedCubeCountByAI()
        {
            collectedCubeCountByAI++;

            if (gameMode == GameMode.TimeChallange)
            {
                UIManager.Instance.SetPlayerScore(collectedCubeCount);
            }
            else if (gameMode == GameMode.RivalAI)
            {
                UIManager.Instance.SetAiScore(collectedCubeCountByAI);
            }
        }

        private void CheckWinLose()
        {
            if (gameMode == GameMode.Classic)
            {
                if (collectedCubeCount >= HCLevelManager.Instance.GetNecessaryCubeNumber())
                {
                    UIManager.Instance.OpenWinPanel();
                }
            }
            else if(gameMode == GameMode.TimeChallange)
            {
                UIManager.Instance.OpenWinPanel();
            }
            else if (gameMode == GameMode.RivalAI)
            {
                if (collectedCubeCount > collectedCubeCountByAI)
                {
                    UIManager.Instance.OpenWinPanel();
                }
                else
                {
                    UIManager.Instance.OpenLosePanel();
                }
            }
        }
    }
}

