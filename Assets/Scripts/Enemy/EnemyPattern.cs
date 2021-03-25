using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour
{

    EnemyMovement enemyMovement;
    [SerializeField]
    EnemyState EnemyState;
    [SerializeField]
    public int selectPattern;

    public BoxCollider2D Tracer;
    int nPlayerLayer;
    private float fLastMoveTime;
    private float fDelay;
    private int nParameter;
    
    


    private void Start()
    {
        Tracer = GetComponent<BoxCollider2D>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
        nPlayerLayer = LayerMask.NameToLayer("Player");
        fLastMoveTime = 0;



    }

    private void Update()
    {
        if (selectPattern.Equals(1))
            Pattern1();

    }



    public void SelectPattern(int _selectNum)
    {
        if (_selectNum.Equals(1))
            Pattern1();



    }

    public void Pattern1()      
    {
        fDelay = Random.Range(1.5f, 3.0f);


        if(Tracer.IsTouchingLayers(nPlayerLayer))
        {
            


        }
        
        else
        {
            

            if(Time.time >= fLastMoveTime + fDelay)
            {
                nParameter = Random.Range(1, 7);

                if(nParameter <= 2)
                {
                    enemyMovement.Move(0.5f);
                }
                else if(nParameter > 2 && nParameter <= 4)
                {
                    enemyMovement.Move(-0.5f);
                }
                else
                {
                    enemyMovement.Move(0);

                }
                fLastMoveTime = Time.time;


            }




        }

    }

    public void Pattern2()      
    {
        


    }




}
