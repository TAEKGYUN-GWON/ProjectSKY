using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour
{

    EnemyMovement enemyMovement;
    public BoxCollider2D Tracer;
    int nPlayerLayer;


    private void Start()
    {
        Tracer = GetComponent<BoxCollider2D>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
        nPlayerLayer = LayerMask.NameToLayer("Player");

    }


    public void SelectPattern(int _selectNum)
    {


    }

    public void Pattern1()      
    {
        if(Tracer.IsTouchingLayers(nPlayerLayer))
        {
            


        }

    }

    public void Pattern2()      
    {
        


    }




}
