using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CurrentSessionData :BaseClass
{
    int _CanvasSortingOrder = 0;

    public int CanvasSortingOrder
    {
        get
        {
            return _CanvasSortingOrder++;
        }
    }
}