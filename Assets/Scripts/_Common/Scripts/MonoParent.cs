using System;
using System.Diagnostics;
using UnityEngine;

public class MonoParent : MonoBehaviour
{

    [HideInInspector] public bool IsInitiated = false;

    /// <summary>
    /// Returns current class name without namespace added
    /// </summary>
    public string ClassName
    {
        get => GetType().Name;
    }

    public string ClassMethodName
    {
        get => GetType().Name + " " + new StackTrace().GetFrame(1).GetMethod().Name + "() ";
    }


    /// <summary>
    /// returns name of method
    ///
    /// return null if somthing wrong happend
    /// </summary>
    public string CurrentMethodName
    {
        get
        {
            try
            {
                return new StackTrace().GetFrame(1).GetMethod().Name;
            }
            catch
            {
                return "";
            }

        }
    }
    public string MethodName
    {
        get
        {
            try
            {
                return new StackTrace().GetFrame(1).GetMethod().Name;
            }
            catch
            {
                return "";
            }

        }
    }
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetScale(Vector3 mScale)
    {
        transform.localScale = mScale;
    }



    public void SetLocalPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }

    public void SetActive(bool val)
    {
        this.gameObject.SetActive(val);
    }

    public bool IsActiveInHeirarchy
    {
        get
        {
            return this.gameObject.activeInHierarchy;
        }
    }
    public bool IsActive
    {
        get
        {
            return this.gameObject.activeSelf;
        }
    }

    public void ShowGameObject()
    {
        gameObject.SetActive(true);
    }

    public void HideGameObject()
    {
        gameObject.SetActive(false);
    }
    public virtual void Show(int fromRequestCode = -1, Action<int> callback = null)
    {
        ShowGameObject();
    }
    public void UpdateCanvasOrder()
    {
        if (!gameObject.GetComponent<Canvas>())
        {
            gameObject.GetComponent<Canvas>().sortingOrder = SaveManager.SessionData.CanvasSortingOrder;
        }
        else
        {
            gameObject.GetComponentInParent<Canvas>().sortingOrder = SaveManager.SessionData.CanvasSortingOrder;

        }
    }

    public virtual void RefreshData() { }
    protected virtual void SetListeners() { }
    protected virtual void RemoveAllListeners() { }
    public virtual void OnInit() { }
    public virtual void PlayButtonClickedSound()
    {
        SoundManager.Instance.PlayButtonClickedSound();
    }

    
}
