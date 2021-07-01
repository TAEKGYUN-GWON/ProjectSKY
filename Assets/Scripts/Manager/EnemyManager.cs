using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    List<EnemyInfo> listEnemy = new List<EnemyInfo>();

    private void Awake()
    {
        LoadEnemys();
        //Debug.Log(listEnemy.Count());
    }
    public EnemyInfo GetEnemyInfo_THEME(E_ENEMY_THEME _eEnemyTheme, E_ENEMY_TYPE _eEnemyType)
    {
        EnemyInfo result = null;

        var info = from n in listEnemy
                   where (n.EnemyTheme == _eEnemyTheme && n.EnemyType==_eEnemyType)
                   select n;

        result = info.FirstOrDefault();
        
        return result;

    }




    public EnemyInfo GetEnemyInfo(int _nIdx)
    {
        EnemyInfo result = null;

        var info = from n in listEnemy
                   where (n.Idx == _nIdx)
                   select n;

        result = info.FirstOrDefault();

        return result;

    }


    void LoadEnemys()
    {
        var table = TableManager.Instance.GetTable("info_enemy");

        for (int i = 0; i < table.Count; ++i)
        {
            var info = table[i];

            int nIdx = info["idx"].GetHashCode();
            int nHp = info["hp"].GetHashCode();
            int nPysical_Dmg = info["pysical_dmg"].GetHashCode();
            float fAttack_Spd = info["attack_spd"].GetHashCode();
            int nCritical_Dmg = info["critical_dmg"].GetHashCode();
            int nCritical_Per = info["critical_per"].GetHashCode();
            int nDef_Point = info["def_point"].GetHashCode();
            int nMove_Spd = info["move_spd"].GetHashCode();
            E_ELEMENT_TYPE eElementType = OS.BitConvert.IntToEnum32<E_ELEMENT_TYPE>(info["elements_type"].GetHashCode());
            E_ENEMY_TYPE eEnemyType = OS.BitConvert.IntToEnum32<E_ENEMY_TYPE>(info["enemy_type"].GetHashCode());
            E_ENEMY_THEME eEnemyTheme = OS.BitConvert.IntToEnum32<E_ENEMY_THEME>(info["enemy_theme"].GetHashCode());
            string strEnemy_Name = info["enemy_name"].ToString();



            var enemyinfo = new EnemyInfo();
            enemyinfo.Initialize(nIdx, nHp, nPysical_Dmg, fAttack_Spd, nCritical_Dmg, nCritical_Per, nDef_Point, nMove_Spd, eElementType, eEnemyType, eEnemyTheme, strEnemy_Name);

            listEnemy.Add(enemyinfo);


        }

    }






}
