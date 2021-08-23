using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{

    EnemyMovement enemyMovement;
    float fDelay;
    float fLastMoveTime;
    int nParameter;
    


    void Start()
    {
        fLastMoveTime = 0;

    }
    public IdleState(EnemyMovement _enemyMovement)
    {
        enemyMovement = _enemyMovement;
    }

    public void OperateEnter()
    {
        Debug.Log("Idlestate");
        if (Time.time > fLastMoveTime + 3f && enemyMovement.bCanMove)
        {
            nParameter = Random.Range(1, 10);
            if (nParameter <= 4)
            {
                enemyMovement.Move(0.7f);
            }
            else if (nParameter > 5 && nParameter <= 8)
            {
                enemyMovement.Move(-0.7f);
            }
            else
            {
                enemyMovement.Move(0);

            }
            fLastMoveTime = Time.time;
        }

    }

    public void OperateUpdate()
    {

    }
    public void OperateExit()
    {

    }



}
