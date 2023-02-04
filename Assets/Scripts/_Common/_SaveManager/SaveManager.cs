using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : BaseClass
{
    #region Initialization 
    public static CurrentSessionData SessionData
    {
        get
        {
            if (_session == null)
            {
                _session = new CurrentSessionData();
            }
            return _session;
        }

    }
    private SaveManager() { }
    private static SaveManager _instance = null;

    private static Dictionary<string, object> data;

    public static SaveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SaveManager();
                data = ToObject<Dictionary<string, object>>(GetStringPrefsData());
                if (data == null)
                {
                    data = new Dictionary<string, object>();
                }
            }
            return _instance;
        }
    }
    private static CurrentSessionData _session;

    #endregion Initialization 

    static void SaveDataInPrefs()
    {
        PlayerPrefs.SetString("k_all_gameData", ToJson(data));
    }

    #region Public Methods

    public static string GetStringPrefsData()
    {
        return PlayerPrefs.GetString("k_all_gameData", "");
    }

    public bool SoundEnabled
    {
        get => data.ContainsKey("k_sound") ? (bool)data["k_sound"] : true;
        set
        {
            if (data.ContainsKey("k_sound"))
            {
                data["k_sound"] = value;
            }
            else
            {
                data.Add("k_sound", value);
            }
            SaveDataInPrefs();
        }
    }

    public bool MusicEnabled
    {
        get => data.ContainsKey("k_music") ? (bool)data["k_music"] : true;
        set
        {
            if (data.ContainsKey("k_music"))
            {
                data["k_music"] = value;
            }
            else
            {
                data.Add("k_music", value);
            }
            SaveDataInPrefs();
        }
    }

    public bool IsAdsRemoved
    {
        get => data.ContainsKey("k_no_ads") ? (bool)data["k_no_ads"] : false;
        set
        {
            if (data.ContainsKey("k_no_ads"))
            {
                data["k_no_ads"] = value;
            }
            else
            {
                data.Add("k_no_ads", value);
            }
            SaveDataInPrefs();
        }
    } 
    public int CoinsCount
    {
        get => data.ContainsKey("k_coins") ? (int)data["k_coins"] : 0;
        set
        {
            if (data.ContainsKey("k_coins"))
            {
                data["k_coins"] = value;
            }
            else
            {
                data.Add("k_coins", value);
            }
            SaveDataInPrefs();
        }
    }
    public HashSet<string> PurchasedProductIds
    {
        get => data.ContainsKey("k_purchased_product_id") ? ToObject<HashSet<string>>(ToJson(data["k_purchased_product_id"])) : new HashSet<string>();

        set
        {
            if (data.ContainsKey("k_purchased_product_id"))
            {
                data["k_purchased_product_id"] = value;
            }
            else
            {
                data.Add("k_purchased_product_id", value);
            }
            SaveDataInPrefs();
        }
    }
    #endregion Public Methods
}
