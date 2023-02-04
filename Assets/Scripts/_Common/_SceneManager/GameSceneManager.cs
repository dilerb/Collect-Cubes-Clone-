using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class GameSceneManager 
{
    public static void LoadHomeScene()
    {
        LoadScene(SceneName.HomeScene);
    }

    public static void LoadGameScene()
    {
        LoadScene(SceneName.GameScene);
    }

    private static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
