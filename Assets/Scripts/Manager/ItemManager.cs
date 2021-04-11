using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager :Singleton<ItemManager>
{
    [SerializeField]
    List<ItemInfo> listItems = new List<ItemInfo>();
    [SerializeField]
    List<WeaponInfo> listWeapons = new List<WeaponInfo>();
    [SerializeField]
    List<EquipInfo> listEquips = new List<EquipInfo>();

    protected void Awake()
    {
        base.Awake();
        LoadItems();
        LoadWeapons();
        LoadEquips();
    }

    public List<ItemInfo> GetItemsFromTier(E_ITEM_TIER _eTier)
    {
        List<ItemInfo> items;

        var info = from n in listItems
                   where (n.ItemTier == _eTier)
                   select n;

        items = info.ToList();

        return items;
    }

    public List<ItemInfo> GetItemsFromTier(E_ITEM_TIER _eTier, E_ITEM_TYPE _eType)
    {
        List<ItemInfo> items;

        var info = from n in listItems
                   where (n.ItemTier == _eTier && n.ItemType == _eType)
                   select n;

        items = info.ToList();

        return items;
    }

    public ItemInfo GetItemInfo(E_ITEM_TYPE _eType, int _nIdx)
    {
        ItemInfo result = null;
        //Linq
        var info = from n in listItems
                   where (n.ItemType == _eType && n.TypeIdx == _nIdx)
                   select n;

        result = info.FirstOrDefault();

        return result;
    }

    public WeaponInfo GetWeaponInfo(E_WEAPON_TYPE _eType, int _nIdx)
    {
        WeaponInfo result = null;

        //Linq
        var info = from n in listWeapons
                   where (n.WeaponType == _eType && n.TypeIdx == _nIdx)
                   select n;

        result = info.FirstOrDefault();

        return result;
    }

    public EquipInfo GetEquipsInfo(E_EQUIP_TYPE _eType, int _nIdx)
    {
        EquipInfo result = null;

        //Linq
        var info = from n in listEquips
                   where (n.EquipType == _eType && n.TypeIdx == _nIdx)
                   select n;

        result = info.FirstOrDefault();

        return result;
    }

    public WeaponInfo GetWeaponInfo(ItemInfo _itemInfo)
    {
        WeaponInfo result = null;

        //Linq
        var info = from n in listWeapons
                   where (n.ItemInfo == _itemInfo)
                   select n;

        result = info.FirstOrDefault();

        return result;
    }

    public EquipInfo GetEquipsInfo(ItemInfo _itemInfo)
    {
        EquipInfo result = null;

        //Linq
        var info = from n in listEquips
                   where (n.ItemInfo == _itemInfo)
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
            string strName = info["name_text_key"].ToString();
            string strInfo = info["info_text_key"].ToString();
            string strIconPath = info["icon_path"].ToString();
            string strSpritePath = info["sprite_path"].ToString();

            var itemInfo = new ItemInfo();
            itemInfo.Initialize(nIdx, eItemType, nTypeIdx, eElemetType, eItemTire, strName, strInfo, strIconPath, strSpritePath);
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
            float fHp = (float) info["hp"];
            float fMoveSpeed = (float) info["move_spd"];
            float fDashSpeed = (float) info["dash_spd"];
            float fDashCount = (float) info["dash_cnt"];
            float fJumpCount = (float) info["jump_cnt"];
            float fJumpForce = (float) info["jump_force"];
            float fFinalDmg = (float) info["final_dmg"];

            var weaponInfo = new WeaponInfo();

            var itemInfo = GetItemInfo(weaponInfo.ItemType, nIdx);

            weaponInfo.Initialize(itemInfo, nIdx, eWeaponType, nTypeIdx, eNormalAttackType, eSkillAttackType,fAttackSpd, fPhysicalPoint, fMagicalPoint, 
                                    fNormalAttackPhysicalCount, fNormalAttackMagicalPoint, fSkillAttackPhysicalCount, fSkillAttackMagicalPoint,
                                    fHp, fMoveSpeed, fDashSpeed, fDashCount, fJumpCount, fJumpForce, fFinalDmg);

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

            float fHp = (float) info["hp"];
            float fPysicalDmg = (float) info["pysical_dmg"];
            float fMagicDmg = (float) info["magic_dmg"];
            float fAttackSpeed = (float) info["attack_spd"];
            float fCriticalDmg = (float) info["critical_dmg"];
            float fCriticalPer = (float) info["critical_per"];
            float fDefPoint = (float) info["def_point"];
            float fMoveSpeed = (float) info["move_spd"];
            float fDashSpeed = (float) info["dash_spd"];
            float fDashCount = (float) info["dash_cnt"];
            float fJumpCount = (float) info["jump_cnt"];
            float fJumpForce = (float) info["jump_force"];
            float fFinalDmg = (float) info["final_dmg"];

            var equipInfo = new EquipInfo();

            var itemInfo = GetItemInfo(equipInfo.ItemType, nIdx);

            equipInfo.Initialize(itemInfo, nIdx, eEquipType, nTypeIdx, fHp, fPysicalDmg, fMagicDmg, fAttackSpeed,
                fCriticalDmg, fCriticalPer, fDefPoint, fMoveSpeed, fDashSpeed, fDashCount, fJumpCount, fJumpForce, fFinalDmg);

            listEquips.Add(equipInfo);
        }
    }
}
