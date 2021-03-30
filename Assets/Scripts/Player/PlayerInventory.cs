using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>
{

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    [SerializeField]
    int nRelicSpace = 10;

    public int RelicSpace => nRelicSpace;

    [SerializeField]
    List<ItemInfo> listItems = new List<ItemInfo>();

    [SerializeField]
    List<EquipInfo> listPlaceEquips = new List<EquipInfo>();

    [SerializeField]
    WeaponInfo placeWeaponInfo;

    [SerializeField]
    SPUM_SpriteList spumSpriteList;

    public bool AddItem(ItemInfo item)
    {
        if(listItems.Count >= nRelicSpace)
        {
            Debug.Log("NOt enough room.");
            return false;
        }

        listItems.Add(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();


        return true;
    }

    public void RemoveItem(ItemInfo item)
    {
        listItems.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }


}
