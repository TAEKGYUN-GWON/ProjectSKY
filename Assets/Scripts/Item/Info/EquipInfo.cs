using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipInfo
{
    public ItemInfo itemInfo;
    public E_ITEM_TYPE eItemType = E_ITEM_TYPE.EQUIP;

    public int nIdx = 0;
    public E_EQUIP_TYPE eEquipType = E_EQUIP_TYPE.NONE;
    public int nTypeIdx = 0;
    public float fDefValue = 0f;
    public float fEffectValue_1 = 0f;
    public float fEffectValue_2 = 0f;
    public float fEffectValue_3 = 0f;
    public float fEffectValue_4 = 0f;

    public ItemInfo ItemInfo => itemInfo;
    public E_ITEM_TYPE ItemType => eItemType;
    public int Idx => nIdx;
    public E_EQUIP_TYPE EquipType => eEquipType;
    public int TypeIdx => nTypeIdx;
    public float DefValue => fDefValue;
    public float EffectValue_1 => fEffectValue_1;
    public float EffectValue_2 => fEffectValue_2;
    public float EffectValue_3 => fEffectValue_3;
    public float EffectValue_4 => fEffectValue_4;

    public void Initialize(ItemInfo _itemInfo, int _nIdx, E_EQUIP_TYPE _eEquipType, int _nTypeIdx, float _fDefValue, float _fEffectValue_1, float _fEffectValue_2, float _fEffectValue_3, float _fEffectValue_4)
    {
        itemInfo = _itemInfo;
        nIdx = _nIdx;
        eEquipType = _eEquipType;
        nTypeIdx = _nTypeIdx;
        fDefValue = _fDefValue;
        fEffectValue_1 = _fEffectValue_1;
        fEffectValue_2 = _fEffectValue_2;
        fEffectValue_3 = _fEffectValue_3;
        fEffectValue_4 = _fEffectValue_4;
    }
}
