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
                    listItems.Add(item);
                    var eqip = ItemManager.Instance.GetEquipsInfo(item);

                    if (eqip != null)
                        ChangeEquip(eqip);
                }
                break;
            case E_ITEM_TYPE.WEAPON:
                {
                    listItems.Add(item);
                    var weapon = ItemManager.Instance.GetWeaponInfo(item);

                    if (weapon != null)
                        placeWeaponInfo = weapon;
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

    void ChangeEquip(EquipInfo _info)
    {
        EquipInfo placeEquipInfo = null;

        //Linq
        var placeEquip = from n in listPlaceEquips
                         where (n.EquipType == _info.EquipType)
                         select n;

        placeEquipInfo = placeEquip.FirstOrDefault();

        if (placeEquipInfo == null)
        {
            listPlaceEquips.Add(_info);
        }
        else
        {
            listPlaceEquips.Remove(placeEquipInfo);

            listPlaceEquips.Add(_info);
        }
    }
}
