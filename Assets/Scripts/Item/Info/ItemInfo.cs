using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    int nIdx = 0;
    E_ITEM_TYPE eItemType = E_ITEM_TYPE.NONE;
    int nTypeIdx = 0;
    E_ELEMENT_TYPE eElementType = E_ELEMENT_TYPE.NONE;
    E_ITEM_TIER eItemTier = E_ITEM_TIER.NONE;
    string strNameKey = "";
    string strInfoKey = "";

    public int Idx => nIdx;
    public E_ITEM_TYPE ItemType => eItemType;
    public int TypeIdx => nTypeIdx;
    public E_ELEMENT_TYPE ElementType => eElementType;
    public E_ITEM_TIER ItemTier => eItemTier;
    public string Name => strNameKey;
    public string Info => strInfoKey;

    void Initialize(int _nIdx, E_ITEM_TYPE _eItemType, int _nTypeId, E_ELEMENT_TYPE _eElementType, E_ITEM_TIER _eItemTier, string _strNameKey, string _strInfoKey)
    {
        nIdx = _nIdx;
        eItemType = _eItemType;
        nTypeIdx = _nTypeId;
        eElementType = _eElementType;
        eItemTier = _eItemTier;
        strNameKey = _strNameKey;
        strInfoKey = _strInfoKey;
    }

}
