using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceState : IState
{
    public BoxCollider2D tracer;
    EnemyMovement enemyMovement;
    Ray2D ray2d;
    Transform target;
    Transform myTransform;
    float traceDistance;

    public TraceState(EnemyMovement _enemyMovement)
    {
        enemyMovement = _enemyMovement;
    }



    public void OperateEnter()
    {
       


    }

    public void OperateUpdate()
    {
       // Debug.Log(Vector2.Distance(myTransform.position, target.position));
        if(myTransform.position.x > target.position.x)
        {
            enemyMovement.Move(-0.7f);
        }
        else if(myTransform.position.x < target.position.x)
        {
            enemyMovement.Move(0.7f);
        }
        else
        {
            enemyMovement.Move(0f);
        }

    }
    public void OperateExit()
    {
        
    }


    public bool isTarget()
    {
        if(target != null)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    public void GetTarget(Transform _Target, Transform _MyTrans)
    {
        target = _Target;
        myTransform = _MyTrans;
    }
    

}
