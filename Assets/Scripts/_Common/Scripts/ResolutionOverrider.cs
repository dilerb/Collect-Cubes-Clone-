using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

    public class ResolutionOverrider : MonoBehaviour
{
    static float defaultZoomLevel = 1.4f;
    static float defaultCanvasScalingMatch = 0.5f;
    protected class ScreenData
    {
        public string Name;
        public int Height;
        public int Width;
        public float ZoomLevel;
        public float CanvasScalingMatch;

        public ScreenData(string name, int height, int width, float zoomLevel, float canvasScalingMatch)
        {

            Name = name;
            Height = height;
            Width = width;
            ZoomLevel = zoomLevel;
            CanvasScalingMatch = canvasScalingMatch;
        }

        public override string ToString()
        {
            string str = "";
            str += "Name: " + Name;
            str += ", Height: " + Height;
            str += ", Width : " + Width;
            str += ", ZoomLevel : " + ZoomLevel;
            str += ", CanvasScalingMatch : " + CanvasScalingMatch;
            return str;
        }
    }



    static List<ScreenData> screens = new List<ScreenData>()
    {
     new ScreenData(
            name: "iPhone XR",
           width: 828,
            height: 1792,
            zoomLevel: 1.4f,
            canvasScalingMatch: 0.0f
        ),
         new ScreenData(
            name: "iPhone XR Max",
           width: 1242,
            height: 2688,
            zoomLevel: 1.4f,
            canvasScalingMatch: 0.0f
        ),
         new ScreenData(
            name: "Samsung Galaxy Note 8",
           width: 1440,
            height: 2960,
            zoomLevel: 1.2f,
            canvasScalingMatch: 0.5f
        ),
         new ScreenData(
            name: "Apple iPad and iPad Air",
           width: 1536,
            height: 2048,
            zoomLevel: 1.6f,
            canvasScalingMatch: 1.0f
        ),
         new ScreenData(
            name: "Apple iPad (7th gen)",
           width: 1620,
            height: 2160,
            zoomLevel: 1.6f,
            canvasScalingMatch: 1.0f
        ),
         new ScreenData(
            name: "Apple iPad Pro 10.15",
           width: 1668,
            height: 2224,
            zoomLevel: 1.6f,
            canvasScalingMatch: 1.0f
        ),
         new ScreenData(
            name: "Apple iPad Pro 11",
           width: 1668,
            height: 2388,
            zoomLevel: 1.6f,
            canvasScalingMatch: 1.0f
        ),
         new ScreenData(
            name: "Apple iPad Pro 12.9 (2018)",
           width: 2048,
            height: 2732,
            zoomLevel: 1.6f,
            canvasScalingMatch: 1.0f
        ),
         new ScreenData(
            name: "Asus ROG Phone",
           width: 1080,
            height: 2160,
            zoomLevel: 1.4f,
            canvasScalingMatch: 0.0f
        ),
         new ScreenData(
            name: "Google Pixel 4",
           width: 1080,
            height: 2280,
            zoomLevel: 1.4f,
            canvasScalingMatch: 0.0f
        ),
         new ScreenData(
            name: "Huawei P20",
           width: 1080,
            height: 2244,
            zoomLevel: 1.4f,
            canvasScalingMatch: 0.25f
        ),
         new ScreenData(
            name: "Huawei Mate 20 Pro",
           width: 1440,
            height: 3120,
            zoomLevel: 1.6f,
            canvasScalingMatch: 0.0f
        ),
         new ScreenData(
            name: "Motorola Moto G7 Power",
           width: 720,
            height: 1520,
            zoomLevel: 1.4f,
            canvasScalingMatch: 0.0f
        ),
         new ScreenData(
            name: "OnePlus 6T",
           width: 1080,
            height: 2340,
            zoomLevel: 1.4f,
            canvasScalingMatch: 0.0f
        ),
         new ScreenData(
            name: "Xiaomi Redmi 6 Pro",
           width: 1080,
            height: 2280,
            zoomLevel: 1.4f,
            canvasScalingMatch: 0.0f
        ),
         new ScreenData(
            name: "Xiaomi Redmi Note 7",
           width: 1080,
            height: 2340,
            zoomLevel: 1.4f,
            canvasScalingMatch: 0.15f
        ),
          new ScreenData(
            name: "HD Phone",
           width: 1080,
            height: 1920,
            zoomLevel: 1.175f,
            canvasScalingMatch: 0.15f
        ),
           new ScreenData(
            name: "HD Phone",
           width: 1080,
            height: 2160,
            zoomLevel: 1.25f,
            canvasScalingMatch: 0.15f
        ),

             new ScreenData(
            name: "HD Phone",
           width: 1440,
            height: 2560,
            zoomLevel: 1.15f,
            canvasScalingMatch: 0.15f
        ),
            new ScreenData(
            name: "HD Phone",
           width: 720,
            height: 1280,
            zoomLevel: 1.15f,
            canvasScalingMatch: 0.15f
        ),
            new ScreenData(
            name: "HD Phone",
           width: 1080,
            height: 2240,
            zoomLevel: 1.1f,
            canvasScalingMatch: 0f
        )
    };


    private void Awake()
    {
        transform.GetComponent<CanvasScaler>().matchWidthOrHeight = GetScalerValue();
       // transform.GetComponent<Canvas>().sortingOrder = Prefs.SessionData.CanvasSortingOrder++;
    }
    static Screen currentResolution;

    public static float GetScalerValue()
    {
        bool flag = false;
        //LogsManager.LogInLine("GetScalerValue:" + Screen.currentResolution);
        for (int i = 0; i < screens.Count; i++)
        {
            if (Screen.height == screens[i].Height && Screen.width == screens[i].Width)
            {
                //LogsManager.LogInLine("GetScalerValue:" + Screen.currentResolution, Screen.resolutions);
                Vall = screens[i].CanvasScalingMatch;
                flag = true;
            }
        }
        if (!flag)
            Vall = defaultCanvasScalingMatch;
        LogsManager.LogInLine("GetScalerValue:" + Vall, Screen.height, Screen.width);
        return Vall;
    }
    static float Vall;
    public static float GetZoomLevel()
    {
        bool flag = false;
        //currentResolution = Screen.currentResolution;
        //LogsManager.LogInLine("GetZoomLevel:" + Screen.currentResolution);
        for (int i = 0; i < screens.Count; i++)
        {
            if (Screen.height == screens[i].Height && Screen.width == screens[i].Width)
            {
                LogsManager.LogInLine("GetZoomLevelssss:    " + screens[i].ToString());
                Vall = screens[i].ZoomLevel;
                flag = true;
            }
        }
        if (!flag)
            Vall = defaultZoomLevel;
        LogsManager.LogInLine("GetZoomLevel:" + Vall, Screen.height, Screen.width);
        return Vall;
    }

    private void OnEnable()
    {
      //  transform.GetComponent<Canvas>().sortingOrder = Prefs.SessionData.CanvasSortingOrder++;
    }
}
