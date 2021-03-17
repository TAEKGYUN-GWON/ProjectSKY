using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipInfo : MonoBehaviour
{
    ItemInfo itemInfo;

    int nIdx = 0;
    E_EQUIP_TYPE eEquipType = E_EQUIP_TYPE.NONE;
    int nTypeIdx = 0;
    float fDefValue = 0f;
    float fEffectValue_1 = 0f;
    float fEffectValue_2 = 0f;
    float fEffectValue_3 = 0f;
    float fEffectValue_4 = 0f;

    public int Idx => nIdx;
    public E_EQUIP_TYPE EquipType => eEquipType;
    public int TypeIdx => nTypeIdx;
    public float DefValue => fDefValue;
    public float EffectValue_1 => fEffectValue_1;
    public float EffectValue_2 => fEffectValue_2;
    public float EffectValue_3 => fEffectValue_3;
    public float EffectValue_4 => fEffectValue_4;
    public ItemInfo ItemInfo => itemInfo;

    void Initialize(ItemInfo _itemInfo, int _nIdx, E_EQUIP_TYPE _eEquipType, int _nTypeIdx, float _fDefValue, float _fEffectValue_1, float _fEffectValue_2, float _fEffectValue_3, float _fEffectValue_4)
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
