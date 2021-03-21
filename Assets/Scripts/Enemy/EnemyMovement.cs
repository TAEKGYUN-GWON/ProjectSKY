using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rigid2D;
    EnemyState enemyState;
    public bool bCanMove;
    public Vector2 hitDirectionRight;
    public Vector2 hitDirectionLeft;



    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        enemyState = GetComponent<EnemyState>();
        bCanMove = true;
        hitDirectionRight = new Vector2(1 , 3);
        hitDirectionLeft = new Vector2(-1, 3);

    }

    public void Move(float _x)
    {
        rigid2D.velocity = new Vector2(_x * enemyState.fMoveSpeed, rigid2D.velocity.y);

    }



    public void Hit(float _x)
    {
        if (_x > 0)
            rigid2D.velocity = hitDirectionRight;
        else
            rigid2D.velocity = hitDirectionLeft;
    }






}
