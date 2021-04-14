using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
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

    public void SpawnEnemy()
    {
        for (int i = 0; i < eEnemyType.Length; i++)
        {

            var newEnemy = Instantiate(Resources.Load("Enemy/"+eEnemyTheme.ToString()+"/"+eEnemyType[i].ToString()), transform.position, transform.rotation) as GameObject;
            newEnemy.GetComponent<EnemyState>().enemydata = EM.GetEnemyInfo_THEME(eEnemyTheme, eEnemyType[i]);
            
            //if (eEnemyTheme == E_ENEMY_THEME.EARTH)
            //{
            //    string k = EM.GetEnemyInfo_THEME(eEnemyTheme, eEnemyType[i]).EnemyName;
            //    eEnemyTheme.ToString();
            //    var newEnemy = Instantiate(Resources.Load(k), transform.position, transform.rotation) as GameObject;



            //}



            
            //if (eEnemyTheme == E_ENEMY_THEME.EARTH)
            //{
            //    var newEnemy = Instantiate(Resources.Load("Enemy/" + EM.GetEnemyInfo(1).EnemyName), transform.position, transform.rotation) as GameObject;
            //    newEnemy.GetComponent<EnemyState>().enemydata = EM.GetEnemyInfo(2);



            //}

        }

    }






}
