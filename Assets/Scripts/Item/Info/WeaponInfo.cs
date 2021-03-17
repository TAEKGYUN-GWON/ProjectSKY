using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo
{
    ItemInfo itemInfo;
    E_ITEM_TYPE eItemType = E_ITEM_TYPE.WEAPON;

    int nIdx = 0;
    E_WEAPON_TYPE eWeaponType = E_WEAPON_TYPE.NONE;
    int nTypeIdx = 0;
    E_ATTACK_TYPE eNoramlAttackType = E_ATTACK_TYPE.PHYSICAL;
    E_ATTACK_TYPE eSkillAttackType = E_ATTACK_TYPE.PHYSICAL;
    float fAttackSpeed = 0f;
    float fPhysicalPoint = 0f;
    float fMagicalPoint = 0f;
    float fNormalAttackPhysicalCount = 0f;
    float fNormalAttackMagicalCount = 0f;
    float fSkillAttackPhysicalCount = 0f;
    float fSkillAttackMagicalCount = 0f;

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


    public void Initialize(ItemInfo _itemInfo, int _nIdx, E_WEAPON_TYPE _eWeaponType, int _nTypeIdx,
        E_ATTACK_TYPE _eNoramlAttackType, E_ATTACK_TYPE _eSkillAttackType,float _fAttackSpeed, float _fPhysicalPoint, 
        float _fMagicalPoint, float _fNormalAttackPhysicalCount, float _fNormalAttackMagicalCount, 
        float _fSkillAttackPhysicalCount, float _fSkillAttackMagicalCount)
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
    }
}
