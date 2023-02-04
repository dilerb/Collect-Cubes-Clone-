using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform panel;
    Rect lastSafeArea = new Rect(0, 0, 0, 0);
    Rect safeArea;

    private void Awake()
    {
        panel = GetComponent<RectTransform>();
        Refresh();
    }

    void Refresh()
    {
        safeArea = GetSafeArea();
        if (safeArea != lastSafeArea)
        {
            ApplySafeArea(safeArea);
        }
    } 

    void Update()
    {
        Refresh();
    }

    Rect GetSafeArea()
    {
        return Screen.safeArea;
    }

    void ApplySafeArea(Rect rect)
    {
        lastSafeArea = rect;

        Vector2 anchorMin = rect.position;
        Vector2 anchorMax = rect.position + rect.size;

        anchorMin.x /= Screen.width;
        anchorMax.x /= Screen.width;

        anchorMin.y /= Screen.height;
        anchorMax.y /= Screen.height;

        panel.anchorMin = anchorMin;
        panel.anchorMax = anchorMax;
    }

}
