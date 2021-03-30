using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equip Info", menuName = "Items/Equip Info")]
public class EquipInfo : ScriptableObject
{
    [SerializeField]
    ItemInfo itemInfo;
    [SerializeField]
    E_ITEM_TYPE eItemType = E_ITEM_TYPE.EQUIP;

    [SerializeField]
    int nIdx = 0;
    [SerializeField]
    E_EQUIP_TYPE eEquipType = E_EQUIP_TYPE.NONE;
    [SerializeField]
    int nTypeIdx = 0;

    [SerializeField]
    float fHp = 0f;
    [SerializeField]
    float fPysicalDmg = 0f;
    [SerializeField]
    float fMagicDmg = 0f;
    [SerializeField]
    float fAttackSpeed = 0f;
    [SerializeField]
    float fCriticalDmg = 0f;
    [SerializeField]
    float fCriticalPer = 0f;
    [SerializeField]
    float fDefPoint = 0f;
    [SerializeField]
    float fMoveSpeed = 0f;
    [SerializeField]
    float fDashSpeed = 0f;
    [SerializeField]
    float fDashCount = 0f;
    [SerializeField]
    float fJumpCount = 0f;
    [SerializeField]
    float fJumpForce = 0f;
    [SerializeField]
    float fFinalDmg = 0f;

    public ItemInfo ItemInfo => itemInfo;
    public E_ITEM_TYPE ItemType => eItemType;
    public int Idx => nIdx;
    public E_EQUIP_TYPE EquipType => eEquipType;
    public int TypeIdx => nTypeIdx;

    public float HP => fHp;
    public float PysicalDmg => fPysicalDmg;
    public float MagicDmg => fMagicDmg;
    public float AttackSpeed => fAttackSpeed;
    public float CriticalDmg => fCriticalDmg;
    public float CriticalPer => fCriticalPer;
    public float DefPoint => fDefPoint;
    public float MoveSpeed => fMoveSpeed;
    public float DashSpeed => fDashSpeed;
    public float DashCount => fDashCount;
    public float JumpCount => fJumpCount;
    public float JumpForce => fJumpForce;
    public float FinalDmg => fFinalDmg;

    public void Initialize(ItemInfo _itemInfo, int _nIdx, E_EQUIP_TYPE _eEquipType, int _nTypeIdx, float _fHp,
        float _fPysicalDmg, float _fMagicDmg, float _fAttackSpeed, float _fCriticalDmg,
        float _fCriticalPer, float _fDefPoint, float _fMoveSpeed, float _fDashSpeed,
        float _fDashCount, float _fJumpCount, float _fJumpForce, float _fFinalDmg)
    {
        itemInfo = _itemInfo;
        nIdx = _nIdx;
        eEquipType = _eEquipType;
        nTypeIdx = _nTypeIdx;

        fHp = _fHp;
        fPysicalDmg = _fPysicalDmg;
        fMagicDmg = _fMagicDmg;
        fAttackSpeed = _fAttackSpeed;
        fCriticalDmg = _fCriticalDmg;
        fCriticalPer = _fCriticalPer;
        fDefPoint = _fDefPoint;
        fMoveSpeed = _fMoveSpeed;
        fDashSpeed = _fDashSpeed;
        fDashCount = _fDashCount;
        fJumpCount = _fJumpCount;
        fJumpForce = _fJumpForce;
        fFinalDmg = _fFinalDmg;

    }
}
