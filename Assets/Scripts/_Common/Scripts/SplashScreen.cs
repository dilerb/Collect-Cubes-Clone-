using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    void Start()
    {
       StartCoroutine (nameof(StartHomeScreen));
    }

    IEnumerator StartHomeScreen() {
        yield return new WaitForSeconds(3);
        GameSceneManager.LoadHomeScene();
    }
}
