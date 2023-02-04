using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;



public class LogsManager
{

    private static string NEW_LINE = "\n";
    private static string DEVIDER = "  ||  ";
    /* 
     * Use this method for important message like response and so on
     */
     
    public static void print(string message)
    {

        MonoBehaviour.print(message);

    }
    /*
    * Use this method for important message like response and so on
    */
     
    public static void print(params object[] messages)
    {

        string printableMessage = "  " + Time.time + "  ";
        try
        {

            foreach (object element in messages)
            {
                if (element is int)
                {
                    printableMessage += (int)element;
                }
                else if (element is float)
                {
                    printableMessage += (float)element;
                }

                else if (element is double)
                {
                    printableMessage += (double)element;
                }

                else if (element is long)
                {
                    printableMessage += (long)element;
                }

                else if (element is string)
                {
                    printableMessage += (string)element;
                }

                else if (element is object)
                {
                    printableMessage += element;
                }

                else if (element is UnityEngine.Object)
                {
                    printableMessage += element;
                }
                printableMessage += NEW_LINE;

            }


        }
        catch (Exception ex)
        {

        }
        MonoBehaviour.print(printableMessage);
    }

    /// <summary>
    /// Use this method print METHOD Name
    
    public static void printMethodName(string message = null, int getStackFrame = 1)
    {

        System.Diagnostics.StackTrace sTrace = new System.Diagnostics.StackTrace();
        System.Diagnostics.StackFrame[] stFrames = sTrace.GetFrames();

        LogInLine(message, "---------------------------");
        if (stFrames.Length > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                MonoBehaviour.print("Method: {0}  - " + stFrames[i].GetMethod());
            }
        }
        //foreach (System.Diagnostics.StackFrame sf in stFrames)
        //{
        //    MonoBehaviour.print("Method: {0}  - " + sf.GetMethod());
        //}



    }
    /// </summary>

    /*
     * Use this method for debuggin purpose only 
     */
     
    public static void Log(params object[] messages)
    {


        string printableMessage = "  " + Time.time + "  ";
        try
        {

            foreach (object element in messages)
            {
                if (element is int)
                {
                    printableMessage += (int)element;
                }
                else if (element is float)
                {
                    printableMessage += (float)element;
                }

                else if (element is double)
                {
                    printableMessage += (double)element;
                }

                else if (element is long)
                {
                    printableMessage += (long)element;
                }

                else if (element is string)
                {
                    printableMessage += (string)element;
                }

                else if (element is object)
                {
                    printableMessage += element;
                }

                else if (element is UnityEngine.Object)
                {
                    printableMessage += element;
                }
                printableMessage += NEW_LINE;

            }


        }
        catch (Exception ex)
        {

        }
        MonoBehaviour.print(printableMessage);
    }
     
    public static void LogInLine(params object[] messages)
    {

        string printableMessage = "  " + Time.time + "  ";
        try
        {

            foreach (object element in messages)
            {
                if (element is int)
                {
                    printableMessage += (int)element;
                }
                else if (element is float)
                {
                    printableMessage += (float)element;
                }

                else if (element is double)
                {
                    printableMessage += (double)element;
                }

                else if (element is long)
                {
                    printableMessage += (long)element;
                }

                else if (element is string)
                {
                    printableMessage += (string)element;
                }

                else if (element is object)
                {
                    printableMessage += element;
                }

                else if (element is UnityEngine.Object)
                {
                    printableMessage += element;
                }
                printableMessage += DEVIDER;

            }

            if (messages != null)
            {
                if (messages.Length > 0)
                {
                    printableMessage = printableMessage.Substring(0, printableMessage.Length - DEVIDER.Length);
                }

            }

        }
        catch (Exception ex)
        {

        }

        MonoBehaviour.print(printableMessage);
    }

    #region Show Error
     [System.Diagnostics.Conditional("ENABLE_LOGS_ERROR")]
    public static void printError(params object[] messages)
    {


        string printableMessage = "  " + Time.time + "  ";
        try
        {

            foreach (object element in messages)
            {
                if (element is int)
                {
                    printableMessage += (int)element;
                }
                else if (element is float)
                {
                    printableMessage += (float)element;
                }

                else if (element is double)
                {
                    printableMessage += (double)element;
                }

                else if (element is long)
                {
                    printableMessage += (long)element;
                }

                else if (element is string)
                {
                    printableMessage += (string)element;
                }

                else if (element is object)
                {
                    printableMessage += element;
                }

                else if (element is UnityEngine.Object)
                {
                    printableMessage += element;
                }
                printableMessage += NEW_LINE;

            }


        }
        catch (Exception ex)
        {

        }
        Debug.LogError(printableMessage);
    }


     [System.Diagnostics.Conditional("ENABLE_LOGS_ERROR")]
    public static void printError(object className, string prependMessgae, Exception ex)
    {
        string printableMessage = "  " + Time.time + "  " + className + DEVIDER + prependMessgae + NEW_LINE;
        try
        {
            printableMessage += "Message: " + ex.Message + NEW_LINE;
            printableMessage += "StackTrace: " + ex.StackTrace + NEW_LINE;
            printableMessage += "In side Try Block: " + NEW_LINE + NEW_LINE;
            Debug.LogError(printableMessage);
        }
        catch
        {
            printableMessage += "In side catch Block: " + NEW_LINE + NEW_LINE;
            Debug.LogError(printableMessage);
        }
    }
    #endregion Show Error

     
    public static void LogDictionary(string prependMessage, IDictionary dictionary)
    {

        prependMessage += " ";
        print(prependMessage + " LogDictionary Called ================================================================================");

        if (dictionary == null)
        {
            print(prependMessage + " LogDictionary dictionary is null ================================================================================");
            return;
        }

        ICollection keys = dictionary.Keys;
        //print("=================   LogDictionary Started  ================= ");
        foreach (string key in keys)
        {
            print(prependMessage + "    Key:" + key + "  ||   " + "Value: " + dictionary[key]);
        }
        print(prependMessage + "================================================================================");

    }

     
    public static void LogList(string prependMessage, IList list)
    {

        if (list == null)
        {
            LogInLine(prependMessage, " list is null ================================================================================");
            return;
        }
        else
        {
        }

        print("=================   LogList Started  ================= ");
        foreach (object item in list)
        {
            LogsManager.LogInLine(prependMessage + "  item:" + item);
        }
        LogInLine(prependMessage, "================================================================================");

    }

    //  
    //public static void LogAllValuesFromRemoteConfig()
    //{
    //    return;
    //    IEnumerable<string> keys = Firebase.RemoteConfig.FirebaseRemoteConfig.Keys;
    //    LogsManager.print("=================   LogAllValuesFromRemoteConfig Started  ====total no Keys============= ");
    //    foreach (string key in keys)
    //    {
    //        LogsManager.LogInLine("Key:" + key + "  ||   " + "Value: " + Firebase.RemoteConfig.FirebaseRemoteConfig.GetValue(key).StringValue);

    //    }
    //    LogsManager.print("=================   LogAllValuesFromRemoteConfig End   ================= ");

    //}

}

