using UnityEngine;


[CreateAssetMenu(fileName ="New Enemy Info", menuName ="Enemy/Enemy Info")]
public class EnemyInfo : ScriptableObject
{
    int nIdx = 0;
    int nHp = 0;
    int nPysical_Dmg = 0;
    float fAttack_Spd = 0;
    int nCritical_Dmg = 0;
    int nCritical_Per = 0;
    int nDef_Point = 0;
    int nMove_Spd = 0;
    E_ELEMENT_TYPE eElementType = E_ELEMENT_TYPE.NONE;
    E_ENEMY_TYPE eEnemyType = E_ENEMY_TYPE.NONE;
    E_ENEMY_THEME eEnemyTheme = E_ENEMY_THEME.NONE;
    string strEnemy_Name = "";


    public int Idx => nIdx;
    public int Hp => nHp;
    public int Pysical_Dmg => nPysical_Dmg;
    public float Attack_Spd => fAttack_Spd;
    public int Critical_Dmg => nCritical_Dmg;
    public int Critical_Per => nCritical_Per;
    public int Def_Point => nDef_Point;
    public int Move_Spd => nMove_Spd;
    public E_ELEMENT_TYPE ElementType => eElementType;
    public E_ENEMY_TYPE EnemyType => eEnemyType;
    public E_ENEMY_THEME EnemyTheme => eEnemyTheme;
    public string EnemyName => strEnemy_Name;

    public void Initialize(int _nIdx, int _nHp, int _nPysical_Dmg, float _fAttack_Spd, int _nCritical_Dmg,
        int _nCritical_Per, int _nDef_Point, int _nMove_Spd, E_ELEMENT_TYPE _eElementType, E_ENEMY_TYPE _eEnemyType,
        E_ENEMY_THEME _eEnemyTheme, string _strEnemy_Name)
    {
        nIdx = _nIdx;
        nHp = _nHp;
        nPysical_Dmg = _nPysical_Dmg;
        fAttack_Spd = _fAttack_Spd;
        nCritical_Dmg = _nCritical_Dmg;
        nCritical_Per = _nCritical_Per;
        nDef_Point = _nDef_Point;
        nMove_Spd = _nMove_Spd;
        eElementType = _eElementType;
        eEnemyType = _eEnemyType;
        eEnemyTheme = _eEnemyTheme;
        strEnemy_Name = _strEnemy_Name;

    }






}
