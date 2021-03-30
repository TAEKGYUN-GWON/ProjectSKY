using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Info", menuName = "Items/Weapon Info")]
public class WeaponInfo : ScriptableObject
{
    [SerializeField]
    ItemInfo itemInfo;
    [SerializeField]
    E_ITEM_TYPE eItemType = E_ITEM_TYPE.WEAPON;

    [SerializeField]
    int nIdx = 0;
    [SerializeField]
    E_WEAPON_TYPE eWeaponType = E_WEAPON_TYPE.NONE;
    [SerializeField]
    int nTypeIdx = 0;
    [SerializeField]
    E_ATTACK_TYPE eNoramlAttackType = E_ATTACK_TYPE.PHYSICAL;
    [SerializeField]
    E_ATTACK_TYPE eSkillAttackType = E_ATTACK_TYPE.PHYSICAL;
    [SerializeField]
    float fAttackSpeed = 0f;
    [SerializeField]
    float fPhysicalPoint = 0f;
    [SerializeField]
    float fMagicalPoint = 0f;
    [SerializeField]
    float fNormalAttackPhysicalCount = 0f;
    [SerializeField]
    float fNormalAttackMagicalCount = 0f;
    [SerializeField]
    float fSkillAttackPhysicalCount = 0f;
    [SerializeField]
    float fSkillAttackMagicalCount = 0f;

    [SerializeField]
    float fHp = 0f;
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
    public E_WEAPON_TYPE WeaponType => eWeaponType;
    public E_ATTACK_TYPE NoramlAttackType => eNoramlAttackType;
    public E_ATTACK_TYPE SkillAttackType => eSkillAttackType;
    public int TypeIdx => nTypeIdx;
    public float AttackSpeed => fAttackSpeed;
    public float PhysicalPoint => fPhysicalPoint;
    public float MagicalPoint => fMagicalPoint;
    public float NormalAttackPhysicalCount => fNormalAttackPhysicalCount;
    public float NormalAttackMagicalCount => fNormalAttackMagicalCount;
    public float SkillAttackPhysicalCount => fSkillAttackPhysicalCount;
    public float SkillAttackMagicalCount => fSkillAttackMagicalCount;

    public float HP => fHp;
    public float MoveSpeed => fMoveSpeed;
    public float DashSpeed => fDashSpeed;
    public float DashCount => fDashCount;
    public float JumpCount => fJumpCount;
    public float JumpForce => fJumpForce;
    public float FinalDmg => fFinalDmg;




    public void Initialize(ItemInfo _itemInfo, int _nIdx, E_WEAPON_TYPE _eWeaponType, int _nTypeIdx,
        E_ATTACK_TYPE _eNoramlAttackType, E_ATTACK_TYPE _eSkillAttackType,float _fAttackSpeed, float _fPhysicalPoint, 
        float _fMagicalPoint, float _fNormalAttackPhysicalCount, float _fNormalAttackMagicalCount, 
        float _fSkillAttackPhysicalCount, float _fSkillAttackMagicalCount, float _fHp,
        float _fMoveSpeed, float _fDashSpeed, float _fDashCount, float _fJumpCount, 
        float _fJumpForce, float _fFinalDmg)
    {
        itemInfo = _itemInfo;
        nIdx = _nIdx;
        eWeaponType = _eWeaponType;
        nTypeIdx = _nTypeIdx;
        eNoramlAttackType = _eNoramlAttackType;
        eSkillAttackType = _eSkillAttackType;
        fAttackSpeed = _fAttackSpeed;
        fPhysicalPoint = _fPhysicalPoint;
        fMagicalPoint = _fMagicalPoint;
        fNormalAttackPhysicalCount = _fNormalAttackPhysicalCount;
        fNormalAttackMagicalCount = _fNormalAttackMagicalCount;
        fSkillAttackPhysicalCount = _fSkillAttackPhysicalCount;
        fSkillAttackMagicalCount = _fSkillAttackMagicalCount;

        fHp = _fHp;
        fMoveSpeed = _fMoveSpeed;
        fDashSpeed = _fDashSpeed;
        fDashCount = _fDashCount;
        fJumpCount = _fJumpCount;
        fJumpForce = _fJumpForce;
        fFinalDmg = _fFinalDmg;
    }
}
