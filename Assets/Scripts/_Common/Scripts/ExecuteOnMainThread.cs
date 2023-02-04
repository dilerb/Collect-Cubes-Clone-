using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ExecuteOnMainThread : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public static Queue<Action> RunOnMainThread = new Queue<Action>();

    void Update()
    {
        if (RunOnMainThread.Count>0)
        {
            while (RunOnMainThread.Count > 0)
            {
                Action action = RunOnMainThread.Dequeue();
                action.Invoke();
            }
        }
    }

}