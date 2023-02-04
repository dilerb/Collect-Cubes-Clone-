 
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using CC;
public static class GameBus
{
    #region Inner Classes

    public class StringMessage : UnityEvent<string> { };
    public class ObjectMessage : UnityEvent<object> { }
    public class IntMessage : UnityEvent<int> { }
    #endregion Inner Classes

    public static UnityEvent OnQuestionSubmittedEvent = new UnityEvent();
    public static UnityEvent OnGameOverEvent = new UnityEvent ();
    public static IntMessage OnScoreUpdatedEvent = new IntMessage();
}
   

