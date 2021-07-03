using System.Collections;
using System.Runtime;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Databox;
using UnityEditor;

public class ItemManager :Singleton<ItemManager>
{
    [SerializeField]
    List<ItemInfo> listItems = new List<ItemInfo>();
    [SerializeField]
    List<WeaponInfo> listWeapons = new List<WeaponInfo>();
    [SerializeField]
    List<EquipInfo> listEquips = new List<EquipInfo>();

    public DataboxObjectManager databoxManager;

    DataboxObject itemDatabox;

    protected void Awake()
    {
        base.Awake();

        databoxManager = AssetDatabase.LoadAssetAtPath<DataboxObjectManager>("Assets/Data/DataManager.asset");
        itemDatabox = databoxManager.GetDataboxObject("ItemData");

        itemDatabox.OnDatabaseLoaded += DataReady;
        itemDatabox.LoadDatabase();
    }
    private void OnDisable()
    {
        itemDatabox.OnDatabaseLoaded -= DataReady;
    }

    void DataReady()
    {
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

    public ItemInfo GetItemInfo(WeaponInfo _weaponInfo)
    {
        ItemInfo result = null;
        //Linq
        var info = from n in listItems
                   where (n.Idx == _weaponInfo.ItemInfo.Idx)
                   select n;

        result = info.FirstOrDefault();

        return result;
    }

    public ItemInfo GetItemInfo(EquipInfo _equipInfo)
    {
        ItemInfo result = null;
        //Linq
        var info = from n in listItems
                   where (n.Idx == _equipInfo.ItemInfo.Idx)
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
        for(int i = 0; i < itemDatabox.GetEntriesFromTable("info_item").Count; ++i)
        {
            string entryName = "item_" + (i+1).ToString();
            var idx = itemDatabox.GetData<IntType>("info_item", entryName, "idx").Value;
            var itemType = itemDatabox.GetData<IntType>("info_item", entryName, "item_type").Value;
            var typeIdx = itemDatabox.GetData<IntType>("info_item", entryName, "type_idx").Value;
            var elemetType = itemDatabox.GetData<IntType>("info_item", entryName, "elements_type").Value;
            var itemTire = itemDatabox.GetData<IntType>("info_item", entryName, "tier").Value;
            var nameKey = itemDatabox.GetData<StringType>("info_item", entryName, "name_text_key").Value;
            var infoKey = itemDatabox.GetData<StringType>("info_item", entryName, "info_text_key").Value;
            var iconPath = itemDatabox.GetData<StringType>("info_item", entryName, "icon_path").Value;
            var spritePath = itemDatabox.GetData<StringType>("info_item", entryName, "sprite_path").Value;

            var itemInfo = new ItemInfo();
            itemInfo.Initialize(idx, OS.BitConvert.IntToEnum32<E_ITEM_TYPE>(itemType), typeIdx, OS.BitConvert.IntToEnum32<E_ELEMENT_TYPE>(elemetType),
                OS.BitConvert.IntToEnum32<E_ITEM_TIER>(itemTire), nameKey, infoKey, iconPath, spritePath);
            listItems.Add(itemInfo);

            string msg = "Name : ";
            OS.Utils.StringBuilder.Clear();
            OS.Utils.StringBuilder.Append(msg);
            OS.Utils.StringBuilder.Append(TextManager.Instance.Text(itemInfo.Name));
            msg = "\nDesc : ";
            OS.Utils.StringBuilder.Append(msg);
            OS.Utils.StringBuilder.Append(TextManager.Instance.Text(itemInfo.Info));
            Debug.Log(OS.Utils.StringBuilder.ToString());
        }

    }

    void LoadWeapons()
    {
        for (int i = 0; i < itemDatabox.GetEntriesFromTable("info_weapon").Count; ++i)
        {
            string entryName = "weapon_" + (i+1).ToString();

            var nIdx = itemDatabox.GetData<IntType>("info_weapon", entryName, "idx").Value;
            var eWeaponType = OS.BitConvert.IntToEnum32<E_WEAPON_TYPE>(itemDatabox.GetData<IntType>("info_weapon", entryName, "weapon_type").Value);
            var nTypeIdx = itemDatabox.GetData<IntType>("info_weapon", entryName, "type_idx").Value;
            var eNormalAttackType = OS.BitConvert.IntToEnum32<E_ATTACK_TYPE>(itemDatabox.GetData<IntType>("info_weapon", entryName, "normal_attack_type").Value);
            var eSkillAttackType = OS.BitConvert.IntToEnum32<E_ATTACK_TYPE>(itemDatabox.GetData<IntType>("info_weapon", entryName, "skill_attack_type").Value);
            var fAttackSpd = itemDatabox.GetData<FloatType>("info_weapon", entryName, "attack_spd").Value;
            var fPhysicalPoint = itemDatabox.GetData<FloatType>("info_weapon", entryName, "physical_point").Value;
            var fMagicalPoint = itemDatabox.GetData<FloatType>("info_weapon", entryName, "magical_point").Value;
            var fNormalAttackPhysicalCount = itemDatabox.GetData<FloatType>("info_weapon", entryName, "nomal_attack_physical_count").Value;
            var fNormalAttackMagicalPoint = itemDatabox.GetData<FloatType>("info_weapon", entryName, "nomal_attack_magical_count").Value;
            var fSkillAttackPhysicalCount = itemDatabox.GetData<FloatType>("info_weapon", entryName, "skill_attack_physical_count").Value;
            var fSkillAttackMagicalPoint = itemDatabox.GetData<FloatType>("info_weapon", entryName, "skill_attack_magical_count").Value;
            var fHp = itemDatabox.GetData<FloatType>("info_weapon", entryName, "hp").Value;
            var fMoveSpeed = itemDatabox.GetData<FloatType>("info_weapon", entryName, "move_spd").Value;
            var fDashSpeed = itemDatabox.GetData<FloatType>("info_weapon", entryName, "dash_spd").Value;
            var fDashCount = itemDatabox.GetData<FloatType>("info_weapon", entryName, "dash_cnt").Value;
            var fJumpCount = itemDatabox.GetData<FloatType>("info_weapon", entryName, "jump_cnt").Value;
            var fJumpForce = itemDatabox.GetData<FloatType>("info_weapon", entryName, "jump_force").Value;
            var fFinalDmg = itemDatabox.GetData<FloatType>("info_weapon", entryName, "final_dmg").Value;


            var weaponInfo = new WeaponInfo();

            var itemInfo = GetItemInfo(weaponInfo.ItemType, nIdx);

            weaponInfo.Initialize(itemInfo, nIdx, eWeaponType, nTypeIdx, eNormalAttackType, eSkillAttackType, fAttackSpd, fPhysicalPoint, fMagicalPoint,
                                    fNormalAttackPhysicalCount, fNormalAttackMagicalPoint, fSkillAttackPhysicalCount, fSkillAttackMagicalPoint,
                                    fHp, fMoveSpeed, fDashSpeed, fDashCount, fJumpCount, fJumpForce, fFinalDmg);

            listWeapons.Add(weaponInfo);
        }

    }

    void LoadEquips()
    {
        for (int i = 0; i < itemDatabox.GetEntriesFromTable("info_equip").Count; ++i)
        {
            string entryName = "equip_" + (i+1).ToString();

            var nIdx = itemDatabox.GetData<IntType>("info_equip", entryName, "idx").Value;
            var eEquipType = OS.BitConvert.IntToEnum32<E_EQUIP_TYPE>(itemDatabox.GetData<IntType>("info_equip", entryName, "equip_type").Value);
            var nTypeIdx = itemDatabox.GetData<IntType>("info_equip", entryName, "type_idx").Value;
            var fHp = itemDatabox.GetData<FloatType>("info_equip", entryName, "hp").Value;
            var fPysicalDmg = itemDatabox.GetData<FloatType>("info_equip", entryName, "pysical_dmg").Value;
            var fMagicDmg = itemDatabox.GetData<FloatType>("info_equip", entryName, "magic_dmg").Value;
            var fAttackSpeed = itemDatabox.GetData<FloatType>("info_equip", entryName, "attack_spd").Value;
            var fCriticalDmg = itemDatabox.GetData<FloatType>("info_equip", entryName, "critical_dmg").Value;
            var fCriticalPer = itemDatabox.GetData<FloatType>("info_equip", entryName, "critical_per").Value;
            var fDefPoint = itemDatabox.GetData<FloatType>("info_equip", entryName, "def_point").Value;
            var fMoveSpeed = itemDatabox.GetData<FloatType>("info_equip", entryName, "move_spd").Value;
            var fDashSpeed = itemDatabox.GetData<FloatType>("info_equip", entryName, "dash_spd").Value;
            var fDashCount = itemDatabox.GetData<FloatType>("info_equip", entryName, "dash_cnt").Value;
            var fJumpCount = itemDatabox.GetData<FloatType>("info_equip", entryName, "jump_cnt").Value;
            var fJumpForce = itemDatabox.GetData<FloatType>("info_equip", entryName, "jump_force").Value;
            var fFinalDmg = itemDatabox.GetData<FloatType>("info_equip", entryName, "final_dmg").Value;

            var equipInfo = new EquipInfo();

            var itemInfo = GetItemInfo(equipInfo.ItemType, nIdx);

            equipInfo.Initialize(itemInfo, nIdx, eEquipType, nTypeIdx, fHp, fPysicalDmg, fMagicDmg, fAttackSpeed,
                fCriticalDmg, fCriticalPer, fDefPoint, fMoveSpeed, fDashSpeed, fDashCount, fJumpCount, fJumpForce, fFinalDmg);

            listEquips.Add(equipInfo);
        }

    }
}
