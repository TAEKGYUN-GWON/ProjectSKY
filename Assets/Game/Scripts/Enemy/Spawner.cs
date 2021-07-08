using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public EnemyManager EM;
    [SerializeField]
    public E_ENEMY_TYPE[] eEnemyType;
    [SerializeField]
    public E_ENEMY_THEME eEnemyTheme;



    private void Start()
    {
        SpawnEnemy();
        
        

        
    }

    public void SpawnEnemy()                                //eEnemyType에 들어있는 에너미 종류들을 테마에 맞게 스폰해줌
    {
        for (int i = 0; i < eEnemyType.Length; i++)         
        {

            var newEnemy = Instantiate(Resources.Load("Enemy/"+eEnemyTheme.ToString()+"/"+eEnemyType[i].ToString()), transform.position, transform.rotation) as GameObject;
            newEnemy.GetComponent<EnemyState>().enemydata = EM.GetEnemyInfo_THEME(eEnemyTheme, eEnemyType[i]);
        }

    }






}
