using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponInfo
{
    public ItemInfo itemInfo;
    public E_ITEM_TYPE eItemType = E_ITEM_TYPE.WEAPON;

    public int nIdx = 0;
    public E_WEAPON_TYPE eWeaponType = E_WEAPON_TYPE.NONE;
    public int nTypeIdx = 0;
    public E_ATTACK_TYPE eNoramlAttackType = E_ATTACK_TYPE.PHYSICAL;
    public E_ATTACK_TYPE eSkillAttackType = E_ATTACK_TYPE.PHYSICAL;
    public float fAttackSpeed = 0f;
    public float fPhysicalPoint = 0f;
    public float fMagicalPoint = 0f;
    public float fNormalAttackPhysicalCount = 0f;
    public float fNormalAttackMagicalCount = 0f;
    public float fSkillAttackPhysicalCount = 0f;
    public float fSkillAttackMagicalCount = 0f;

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
