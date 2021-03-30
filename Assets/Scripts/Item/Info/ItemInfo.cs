using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Info", menuName = "Items/Item Info")]
public class ItemInfo : ScriptableObject
{
    [SerializeField]
    int nIdx = 0;
    [SerializeField]
    E_ITEM_TYPE eItemType = E_ITEM_TYPE.NONE;
    [SerializeField]
    int nTypeIdx = 0;
    [SerializeField]
    E_ELEMENT_TYPE eElementType = E_ELEMENT_TYPE.NONE;
    [SerializeField]
    E_ITEM_TIER eItemTier = E_ITEM_TIER.NONE;
    [SerializeField]
    string strNameKey = "";
    [SerializeField]
    string strInfoKey = "";

    [SerializeField]
    string strSpritePath = "";

    [SerializeField]
    Sprite icon = null;

    public int Idx => nIdx;
    public E_ITEM_TYPE ItemType => eItemType;
    public int TypeIdx => nTypeIdx;
    public E_ELEMENT_TYPE ElementType => eElementType;
    public E_ITEM_TIER ItemTier => eItemTier;
    public string Name => strNameKey;
    public string Info => strInfoKey;
    public string SpritePath => strSpritePath;

    public void Initialize(int _nIdx, E_ITEM_TYPE _eItemType, int _nTypeId, E_ELEMENT_TYPE _eElementType, 
        E_ITEM_TIER _eItemTier, string _strNameKey, string _strInfoKey, string _strSpritePath)
    {
        nIdx = _nIdx;
        eItemType = _eItemType;
        nTypeIdx = _nTypeId;
        eElementType = _eElementType;
        eItemTier = _eItemTier;
        strNameKey = _strNameKey;
        strInfoKey = _strInfoKey;
        strSpritePath = _strSpritePath;
    }

}
