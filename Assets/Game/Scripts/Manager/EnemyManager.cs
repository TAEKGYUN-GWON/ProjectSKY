using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Databox;


public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField]
    List<EnemyInfo> listEnemy = new List<EnemyInfo>();

    DataboxObject enemyDataBox;

    protected void Awake()
    {
        base.Awake();

        enemyDataBox = OS.Utils.DataboxObjectManager.GetDataboxObject("EnemyData");

        enemyDataBox.OnDatabaseLoaded += DataReady;
        enemyDataBox.LoadDatabase();

        //Debug.Log(listEnemy.Count());
    }

    private void OnDisable()
    {
        enemyDataBox.OnDatabaseLoaded -= DataReady;
    }


    void DataReady()
    {
        LoadEnemys();
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
        Debug.Log("LoadEnemy");

        for (int i = 0; i < enemyDataBox.GetEntriesFromTable("info_enemy").Count; ++i)
        {
            string entryName = "enemy_" + (i + 1).ToString();
            int nIdx = enemyDataBox.GetData<IntType>("info_enemy", entryName, "idx").Value;
            int nHp = enemyDataBox.GetData<IntType>("info_enemy", entryName, "hp").Value;
            int nPysical_Dmg = enemyDataBox.GetData<IntType>("info_enemy", entryName, "pysical_dmg").Value;
            float fAttack_Spd = enemyDataBox.GetData<FloatType>("info_enemy", entryName, "attack_spd").Value;
            int nCritical_Dmg = enemyDataBox.GetData<IntType>("info_enemy", entryName, "critical_dmg").Value;

            int nCritical_Per = enemyDataBox.GetData<IntType>("info_enemy", entryName, "critical_per").Value;

            int nDef_Point = enemyDataBox.GetData<IntType>("info_enemy", entryName, "def_point").Value;
            int nMove_Spd = enemyDataBox.GetData<IntType>("info_enemy", entryName, "move_spd").Value;
            E_ELEMENT_TYPE eElementType = OS.BitConvert.IntToEnum32<E_ELEMENT_TYPE>(enemyDataBox.GetData<IntType>("info_enemy",entryName,"elements_type").Value);
            E_ENEMY_TYPE eEnemyType = OS.BitConvert.IntToEnum32<E_ENEMY_TYPE>(enemyDataBox.GetData<IntType>("info_enemy", entryName, "enemy_type").Value);
            E_ENEMY_THEME eEnemyTheme = OS.BitConvert.IntToEnum32<E_ENEMY_THEME>(enemyDataBox.GetData<IntType>("info_enemy", entryName, "enemy_theme").Value);
            string strEnemy_Name = enemyDataBox.GetData<StringType>("info_enemy", entryName, "enemy_name").Value;

            var enemyinfo = new EnemyInfo();
            enemyinfo.Initialize(nIdx, nHp, nPysical_Dmg, fAttack_Spd, nCritical_Dmg, nCritical_Per, nDef_Point, nMove_Spd, eElementType, eEnemyType, eEnemyTheme, strEnemy_Name);

            listEnemy.Add(enemyinfo);


        }




        //for (int i = 0; i < table.Count; ++i)
        //{
        //    var info = table[i];

        //    int nIdx = info["idx"].GetHashCode();
        //    int nHp = info["hp"].GetHashCode();
        //    int nPysical_Dmg = info["pysical_dmg"].GetHashCode();
        //    float fAttack_Spd = info["attack_spd"].GetHashCode();
        //    int nCritical_Dmg = info["critical_dmg"].GetHashCode();
        //    int nCritical_Per = info["critical_per"].GetHashCode();
        //    int nDef_Point = info["def_point"].GetHashCode();
        //    int nMove_Spd = info["move_spd"].GetHashCode();
        //    E_ELEMENT_TYPE eElementType = OS.BitConvert.IntToEnum32<E_ELEMENT_TYPE>(info["elements_type"].GetHashCode());
        //    E_ENEMY_TYPE eEnemyType = OS.BitConvert.IntToEnum32<E_ENEMY_TYPE>(info["enemy_type"].GetHashCode());
        //    E_ENEMY_THEME eEnemyTheme = OS.BitConvert.IntToEnum32<E_ENEMY_THEME>(info["enemy_theme"].GetHashCode());
        //    string strEnemy_Name = info["enemy_name"].ToString();



        //    var enemyinfo = new EnemyInfo();
        //    enemyinfo.Initialize(nIdx, nHp, nPysical_Dmg, fAttack_Spd, nCritical_Dmg, nCritical_Per, nDef_Point, nMove_Spd, eElementType, eEnemyType, eEnemyTheme, strEnemy_Name);

        //    listEnemy.Add(enemyinfo);


        //}

    }






}
