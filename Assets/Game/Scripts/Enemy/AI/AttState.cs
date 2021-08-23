using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttState : IState
{
    EnemyMovement enemyMovement;
    Animator animator;
    float fLastAttTime;


    public AttState(EnemyMovement _enemyMovement,Animator _animator)
    {
        enemyMovement = _enemyMovement;
        animator = _animator;
        fLastAttTime = 0;
    }


    public void OperateEnter()
    {
        if (Time.time >= fLastAttTime + 3)
        {
            enemyMovement.Move(0);
            fLastAttTime = Time.time;
            animator.SetTrigger("Attack");
        }
        Debug.Log("ATTON");

    }

    public void OperateUpdate()
    {


    }

    public void OperateExit()
    {

    }

}
