using CC.Managers.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace CC.Managers
{
    [System.Serializable]
    public class HCLevel
    {

        public GameObject levelPrefab;
        public int necessaryCubeNumber;
        public int time;
    }
    public class HCLevelManager : SingletonMono<HCLevelManager>
    {
        public List<HCLevel> _levelPrefabs;
        [SerializeField] internal int _levelIndex = 0;
        [SerializeField] internal bool _forceLevel = false;

        private int _globalLevelIndex = 0;
        private bool _inited = false;
        internal GameObject _currentLevel;

        public void Init()
        {
            if (_inited)
            {
                return;
            }

            _inited = true;
            //PlayerPrefs.DeleteAll();
            _globalLevelIndex = PlayerPrefs.GetInt("HCLevel" + GameManager.Instance.gameMode.ToString());
            if (_forceLevel)
            {
                _globalLevelIndex = _levelIndex;
                return;
            }
            _levelIndex = _globalLevelIndex;
            if (_levelIndex >= _levelPrefabs.Count)
            {
                _levelIndex = GameUtility.RandomInt(_levelPrefabs.Count);
            }
        }
        public void GenerateCurrentLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel);
            }

            _currentLevel = Instantiate(_levelPrefabs[_levelIndex].levelPrefab);
        }

        public GameObject GetCurrentLevel()
        {
            return _currentLevel;
        }

        public void LevelUp()
        {
            if (_forceLevel)
            {
                Debug.Log("ForceReturn");
                return;
            }
            _globalLevelIndex++;
            PlayerPrefs.SetInt("HCLevel" + GameManager.Instance.gameMode.ToString(), _globalLevelIndex);
            _levelIndex = _globalLevelIndex;
            if (_levelIndex >= _levelPrefabs.Count)
            {
                _levelIndex = GameUtility.RandomIntExcept(_levelPrefabs.Count, _levelIndex);
            }
        }
        public int GetGlobalLevelIndex()
        {
            return _globalLevelIndex;
        }

        public int GetNecessaryCubeNumber()
        {
            return _levelPrefabs[_levelIndex].necessaryCubeNumber;
        }
        public int GetTimeLimit()
        {
            return _levelPrefabs[_levelIndex].time;
        }
    }
}