using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
            Debug.Log("Not enough room.");
            return false;
        }

        ItemClassification(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();


        return true;
    }

    public void RemoveItem(ItemInfo item)
    {
        listItems.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    void ItemClassification(ItemInfo item)
    {
        switch(item.ItemType)
        {
            case E_ITEM_TYPE.EQUIP:
                {
                    ChangeEquip(item);
                }
                break;
            case E_ITEM_TYPE.WEAPON:
                {
                    ChangeWeapon(item);
                }
                break;
            case E_ITEM_TYPE.ESSENCE:
                {

                }
                break;
            case E_ITEM_TYPE.BLESS:
                {

                }
                break;
        }
    }

    void ChangeWeapon(ItemInfo item)
    {
        var waepon = ItemManager.Instance.GetWeaponInfo(item);
        if (waepon == null)
            return;

        if (placeWeaponInfo == null)
        {
            listItems.Add(item);
            placeWeaponInfo = waepon;
        }
        else
        {
            listItems.Remove(item);

            listItems.Add(item);
            placeWeaponInfo = waepon;
        }
    }

    void ChangeEquip(ItemInfo item)
    {
        var eqip = ItemManager.Instance.GetEquipsInfo(item);
        if (eqip == null)
            return;

        EquipInfo placeEquipInfo = null;

        //Linq
        var placeEquip = from n in listPlaceEquips
                         where (n.EquipType == eqip.EquipType)
                         select n;

        placeEquipInfo = placeEquip.FirstOrDefault();

        if (placeEquipInfo == null)
        {
            listItems.Add(item);
            listPlaceEquips.Add(eqip);
        }
        else
        {
            listItems.Remove(item);
            listPlaceEquips.Remove(placeEquipInfo);

            listItems.Add(item);
            listPlaceEquips.Add(eqip);
        }
    }
}
