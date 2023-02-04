using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_Device_Type
{
    Tablet,
    Phone,
    UnknownDevice
}

public static class DeviceTypeChecker
{
    public static bool isTablet;
    public static float PhoneDeviceDiagonalInches = 4.7f;
    public static float TabletDeviceDiagonalInches = 6.5f;
    public static float TallDeviceDiagonalInches = 5.8f;

    public static float DeviceDiagonalSizeInInches()
    {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;
        float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

        

        return diagonalInches;
    }

    public static ENUM_Device_Type GetDeviceType()
    {
        float _screenWidth = Mathf.Min(Screen.width, Screen.height);
        float _screenHeight = Mathf.Max(Screen.width, Screen.height);
        float aspectRatio = _screenHeight / _screenWidth;
        bool isTablet = (DeviceDiagonalSizeInInches() > TabletDeviceDiagonalInches && aspectRatio < 2f);
                  
        

        if (isTablet)
        {
            return ENUM_Device_Type.Tablet;
        }
        else
        {
            return ENUM_Device_Type.Phone;
        }
        
    }

    public static bool IsTabOrIpad
    {
        get
        {
            if (DeviceTypeChecker.GetDeviceType() == ENUM_Device_Type.Tablet)
            {
                if (DeviceTypeChecker.DeviceDiagonalSizeInInches() > DeviceTypeChecker.TabletDeviceDiagonalInches)
                {
                    return true;
                }
            }

            return false;
        }

    }
}

