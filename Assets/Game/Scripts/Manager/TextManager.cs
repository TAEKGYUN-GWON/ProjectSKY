using Databox;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TextManager : Singleton<TextManager>
{
    [SerializeField]
    List<ItemInfo> listItems = new List<ItemInfo>();
    [SerializeField]
    List<WeaponInfo> listWeapons = new List<WeaponInfo>();
    [SerializeField]
    List<EquipInfo> listEquips = new List<EquipInfo>();

    public DataboxObjectManager databoxManager;

    DataboxObject textDatabox;

    string strLanguage = "";

    protected void Awake()
    {
        base.Awake();

        databoxManager = AssetDatabase.LoadAssetAtPath<DataboxObjectManager>("Assets/Data/DataManager.asset");
        textDatabox = databoxManager.GetDataboxObject("Text");

        textDatabox.OnDatabaseLoaded += DataReady;
        textDatabox.LoadDatabase();
        SetLanguage(Application.systemLanguage);
    }
    private void OnDisable()
    {
        textDatabox.OnDatabaseLoaded -= DataReady;
    }
    void DataReady()
    {
    }
    
    public void SetLanguage(SystemLanguage systemLanguage)
    {
        switch (systemLanguage)
        {
            case SystemLanguage.English: strLanguage = "English"; break;
            case SystemLanguage.Chinese: strLanguage = "Chinese"; break;
            case SystemLanguage.Japanese: strLanguage = "Japanese"; break;
            case SystemLanguage.Korean: strLanguage = "Korean"; break;
            default: strLanguage = "English"; break;
        }
    }

    public string Text(string strKey)
    {
        StringType result = new StringType();

        if (strKey != null && textDatabox.TryGetData("game_text", strKey, strLanguage, out result))
            return result.Value;

        return "";
    }
}
