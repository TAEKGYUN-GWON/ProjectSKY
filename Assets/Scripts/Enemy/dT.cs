using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dT : MonoBehaviour
{
    EnemyInfo data;
    [SerializeField]
    public EnemyManager EM;


    private void Start()
    {
        data = EM.GetEnemyInfo(1);
        



    }


}
