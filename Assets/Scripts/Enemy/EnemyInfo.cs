using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyInfo : MonoBehaviour
{
    public int nIdx = 0;
    public int nHp = 0;
    public int nPysical_Dmg = 0;
    public float fAttack_Spd = 0;
    public int nCritical_Dmg = 0;
    public int nCritical_Per = 0;
    public int nDef_Point = 0;
    public int nMove_Spd = 0;
    public E_ELEMENT_TYPE eElementType = E_ELEMENT_TYPE.NONE;
    public E_ENEMY_PATTERN eEnemyPattern = E_ENEMY_PATTERN.NONE;

    public int Idx => nIdx;
    public int Hp => nHp;
    public int Pysical_Dmg => nPysical_Dmg;
    public float Attack_Spd => fAttack_Spd;
    public int Critical_Dmg => nCritical_Dmg;
    public int Critical_Per => nCritical_Per;
    public int Def_Point => nDef_Point;
    public int Move_Spd => nMove_Spd;
    public E_ELEMENT_TYPE ElementType => eElementType;
    public E_ENEMY_PATTERN EnemyPattern => eEnemyPattern;

    public void Initialize(int _nIdx, int _nHp, int _nPysical_Dmg, float _fAttack_Spd, int _nCritical_Dmg, int _nCritical_Per, int _nDef_Point, int _nMove_Spd, E_ELEMENT_TYPE _eElemntType, E_ENEMY_PATTERN _eEnemyPattern)
    {
        nIdx = _nIdx;
        nHp = _nHp;
        nPysical_Dmg = _nPysical_Dmg;
        fAttack_Spd = _fAttack_Spd;
        nCritical_Dmg = _nCritical_Dmg;
        nCritical_Per = _nCritical_Per;
        nDef_Point = _nDef_Point;
        nMove_Spd = _nMove_Spd;
        eElementType = _eElemntType;
        eEnemyPattern = _eEnemyPattern;
    }






}
