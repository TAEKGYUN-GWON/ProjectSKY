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
    public List<ItemInfo> ListItems => listItems;

    [SerializeField]
    List<EquipInfo> listPlaceEquips = new List<EquipInfo>();

    [SerializeField]
    WeaponInfo placeWeaponInfo = null;

    [SerializeField]
    PlayerController playerController = null;

    public bool AddItem(ItemInfo item)
    {
        if(listItems.Count >= nRelicSpace)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        ItemChange(item);

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

    public List<ItemInfo> GetItemInfos(E_INVENTORY_SLOT_TYPE _eType)
    {
        List<ItemInfo> result = new List<ItemInfo>();

        var info = from n in listItems
                   where (IsSlotType(n, _eType))
                   select n;

        result = info.ToList();

        return result;
    }

    private static bool IsSlotType(ItemInfo _info, E_INVENTORY_SLOT_TYPE _eType)
    {
        bool result = false;
        switch(_eType)
        {
            case E_INVENTORY_SLOT_TYPE.HELMET:
                {
                    if (_info.ItemType == E_ITEM_TYPE.EQUIP)
                    {
                        var equipInfo = ItemManager.Instance.GetEquipsInfo(_info);
                        if(equipInfo != null)
                        {
                            if(equipInfo.EquipType == E_EQUIP_TYPE.HELMET)
                                result = true;
                        }
                    }
                }
                break;
            case E_INVENTORY_SLOT_TYPE.ARMOR_TOP:
                {
                    if (_info.ItemType == E_ITEM_TYPE.EQUIP)
                    {
                        var equipInfo = ItemManager.Instance.GetEquipsInfo(_info);
                        if (equipInfo != null)
                        {
                            if (equipInfo.EquipType == E_EQUIP_TYPE.ARMOR_TOP)
                                result = true;
                        }
                    }
                }
                break;
            case E_INVENTORY_SLOT_TYPE.ARMOR_PANTS:
                {
                    if (_info.ItemType == E_ITEM_TYPE.EQUIP)
                    {
                        var equipInfo = ItemManager.Instance.GetEquipsInfo(_info);
                        if (equipInfo != null)
                        {
                            if (equipInfo.EquipType == E_EQUIP_TYPE.ARMOR_PANTS)
                                result = true;
                        }
                    }
                }
                break;
            case E_INVENTORY_SLOT_TYPE.WEAPON:
                {
                    if (_info.ItemType == E_ITEM_TYPE.WEAPON)
                        result = true;
                }
                break;
            case E_INVENTORY_SLOT_TYPE.ESSENCE_GROUP:
                {
                    if (_info.ItemType == E_ITEM_TYPE.ESSENCE)
                        result = true;
                }
                break;
            case E_INVENTORY_SLOT_TYPE.ESSENCE_GENERAL:
                {
                    if (_info.ItemType == E_ITEM_TYPE.ESSENCE)
                        result = true;
                }
                break;
            case E_INVENTORY_SLOT_TYPE.BLESS:
                {
                    if (_info.ItemType == E_ITEM_TYPE.BLESS)
                        result = true;
                }
                break;
            case E_INVENTORY_SLOT_TYPE.RELIC:
                {
                    if (_info.ItemType == E_ITEM_TYPE.RELIC)
                        result = true;
                }
                break;
        }

        return result;
    }

    void ItemChange(ItemInfo item)
    {
        if(playerController == null)
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        ItemClassification(item);
        playerController.ItemSetup(item);
    }

    private void ItemClassification(ItemInfo item)
    {
        switch (item.ItemType)
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
            listItems.Remove(ItemManager.Instance.GetItemInfo(placeWeaponInfo));

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
            listItems.Remove(ItemManager.Instance.GetItemInfo(placeEquipInfo));
            listPlaceEquips.Remove(placeEquipInfo);

            listItems.Add(item);
            listPlaceEquips.Add(eqip);
        }
    }
}
