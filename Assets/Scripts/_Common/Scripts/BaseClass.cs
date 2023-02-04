using System;
using System.Diagnostics;
using System.Xml;
using UnityEngine;
//using Unity.Plastic.Newtonsoft.Json;

public class BaseClass : LogsManager
{
    public string ToJson(bool isformatted = false)
    {
        return JsonUtility.ToJson(this);
    }

    public static T ToObject<T>(string json)
    {
        if (string.IsNullOrEmpty(json))
        {
            return Activator.CreateInstance<T>();
        }
        return JsonUtility.FromJson<T>(json);
    }


    public static string ToJson(object obj, bool isformatted = false)
    {
        if (obj == null)
        {
            return "null";
        }
        else
        {
            return JsonUtility.ToJson(obj);
        }
    }
    public  string GetClassName()
    { 
            return GetType().Name;
    }

    public static string GetMethodName()
    {
        
            return new StackTrace().GetFrame(1).GetMethod().Name;
    }

    public   string GetClassMethodName()
    {
       
            return GetType().Name + " " + new StackTrace().GetFrame(1).GetMethod().Name + " ";
    }
    
}
 
