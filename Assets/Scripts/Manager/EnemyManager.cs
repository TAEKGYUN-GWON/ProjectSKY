using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    List<EnemyInfo> listEnemy = new List<EnemyInfo>();

    private void Awake()
    {
        LoadEnemys();
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
            




        }




    }




}
