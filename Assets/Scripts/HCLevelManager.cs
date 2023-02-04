using CC.Managers.Utility;
using UnityEngine;

namespace CC.Managers
{
    public class HCLevelManager : SingletonMono<HCLevelManager>
    {
        [SerializeField] private GameObject[] _levelPrefabs;
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
            _globalLevelIndex = PlayerPrefs.GetInt("HCLevel");
            if (_forceLevel)
            {
                _globalLevelIndex = _levelIndex;
                return;
            }
            _levelIndex = _globalLevelIndex;
            if (_levelIndex >= _levelPrefabs.Length)
            {
                _levelIndex = GameUtility.RandomIntExcept(_levelPrefabs.Length, _levelIndex, 0);
            }
        }
        public void GenerateCurrentLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel);
            }
            _currentLevel = Instantiate(_levelPrefabs[_levelIndex]);
            //HomaGames.HomaBelly.DefaultAnalytics.LevelStarted(_globalLevelIndex);
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
            PlayerPrefs.SetInt("HCLevel", _globalLevelIndex);
            _levelIndex = _globalLevelIndex;
            if (_levelIndex >= _levelPrefabs.Length)
            {
                _levelIndex = GameUtility.RandomIntExcept(_levelPrefabs.Length, _levelIndex);
            }
            Debug.Log(_levelIndex);
        }
        public int GetGlobalLevelIndex()
        {
            return _globalLevelIndex;
        }
    }
}