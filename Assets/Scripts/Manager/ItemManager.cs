using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager :Singleton<ItemManager>
{

    List<ItemInfo> listItems = new List<ItemInfo>();
    List<WeaponInfo> listWeapons = new List<WeaponInfo>();
    List<EquipInfo> listEquips = new List<EquipInfo>();


    private void Awake()
    {
        LoadItems();
        LoadWeapons();
        LoadEquips();

        int a = 0;
    }


    ItemInfo GetItemInfo(E_ITEM_TYPE _eType, int _nIdx)
    {
        ItemInfo result = null;
        //Linq
        var info = from n in listItems
                   where (n.ItemType == _eType && n.TypeIdx == _nIdx)
                   select n;

        result = info.FirstOrDefault();

        return result;
    }

    WeaponInfo GetWeaponInfo(E_WEAPON_TYPE _eType, int _nIdx)
    {
        WeaponInfo result = null;

        //Linq
        var info = from n in listWeapons
                   where (n.WeaponType == _eType && n.TypeIdx == _nIdx)
                   select n;

        result = info.FirstOrDefault();

        return result;
    }

    EquipInfo GetEquipsInfo(E_EQUIP_TYPE _eType, int _nIdx)
    {
        EquipInfo result = null;

        //Linq
        var info = from n in listEquips
                   where (n.EquipType == _eType && n.TypeIdx == _nIdx)
                   orderby n
                   select n;

        result = info.FirstOrDefault();

        return result;
    }

    void LoadItems()
    {
        var table = TableManager.Instance.GetTable("info_item");

        for(int i = 0; i < table.Count; ++i)
        {
            var info = table[i];

            int nIdx = info["idx"].GetHashCode();
            E_ITEM_TYPE eItemType = OS.BitConvert.IntToEnum32<E_ITEM_TYPE>(info["item_type"].GetHashCode());
            int nTypeIdx = info["type_idx"].GetHashCode();
            E_ELEMENT_TYPE eElemetType = OS.BitConvert.IntToEnum32<E_ELEMENT_TYPE>(info["elements_type"].GetHashCode());
            E_ITEM_TIER eItemTire = OS.BitConvert.IntToEnum32<E_ITEM_TIER>(info["tier"].GetHashCode());
            string strName = "";
            string strInfo = "";

            var itemInfo = new ItemInfo();
            itemInfo.Initialize(nIdx, eItemType, nTypeIdx, eElemetType, eItemTire, strName, strInfo);
            listItems.Add(itemInfo);
        }
    }

    void LoadWeapons()
    {
        var table = TableManager.Instance.GetTable("info_weapon");

        for (int i = 0; i < table.Count; ++i)
        {
            var info = table[i];

            int nIdx = info["idx"].GetHashCode();
            E_WEAPON_TYPE eWeaponType = OS.BitConvert.IntToEnum32<E_WEAPON_TYPE>(info["weapon_type"].GetHashCode());
            int nTypeIdx = info["type_idx"].GetHashCode();
            E_ATTACK_TYPE eNormalAttackType = OS.BitConvert.IntToEnum32<E_ATTACK_TYPE>(info["normal_attack_type"].GetHashCode());
            E_ATTACK_TYPE eSkillAttackType = OS.BitConvert.IntToEnum32<E_ATTACK_TYPE>(info["skill_attack_type"].GetHashCode());
            float fAttackSpd = (float) info["attack_spd"];
            float fPhysicalPoint = (float) info["physical_point"];
            float fMagicalPoint = (float) info["magical_point"];
            float fNormalAttackPhysicalCount = (float) info["nomal_attack_physical_count"];
            float fNormalAttackMagicalPoint = (float) info["nomal_attack_magical_count"];
            float fSkillAttackPhysicalCount = (float) info["skill_attack_physical_count"];
            float fSkillAttackMagicalPoint = (float) info["skill_attack_magical_count"];

            var weaponInfo = new WeaponInfo();

            var itemInfo = GetItemInfo(weaponInfo.ItemType, nIdx);

            weaponInfo.Initialize(itemInfo, nIdx, eWeaponType, nTypeIdx, eNormalAttackType, eSkillAttackType,fAttackSpd, fPhysicalPoint, fMagicalPoint, 
                                    fNormalAttackPhysicalCount, fNormalAttackMagicalPoint, fSkillAttackPhysicalCount, fSkillAttackMagicalPoint);

            listWeapons.Add(weaponInfo);
        }
    }

    void LoadEquips()
    {
        var table = TableManager.Instance.GetTable("info_equip");

        for (int i = 0; i < table.Count; ++i)
        {
            var info = table[i];

            int nIdx = info["idx"].GetHashCode();
            E_EQUIP_TYPE eEquipType = OS.BitConvert.IntToEnum32<E_EQUIP_TYPE>(info["equip_type"].GetHashCode());
            int nTypeIdx = info["type_idx"].GetHashCode();
            float fDefensiveValue = (float) info["defensive_value"];
            float fEffectValue_1 = (float) info["effect_value_1"];
            float fEffectValue_2 = (float) info["effect_value_2"];
            float fEffectValue_3 = (float) info["effect_value_3"];
            float fEffectValue_4 = (float) info["effect_value_4"];

            var equipInfo = new EquipInfo();

            var itemInfo = GetItemInfo(equipInfo.ItemType, nIdx);

            equipInfo.Initialize(itemInfo, nIdx, eEquipType, nTypeIdx, fDefensiveValue, fEffectValue_1, fEffectValue_2, fEffectValue_3, fEffectValue_4);

            listEquips.Add(equipInfo);
        }
    }
}
