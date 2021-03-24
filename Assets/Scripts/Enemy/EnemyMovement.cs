using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    EnemyState enemyState;
    public bool bCanMove;


    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        enemyState = GetComponent<EnemyState>();
        bCanMove = true;


    }

    public void Move(float _x)
    {
        rigid2D.velocity = new Vector2(_x * enemyState.fMoveSpeed, rigid2D.velocity.y);
    }



    public void Hit(float _x)
    {
        rigid2D.velocity = new Vector2(_x * enemyState.fMoveSpeed, rigid2D.velocity.y);




    }

    private void Update()
    {
        //Move(-1);
    }




}
